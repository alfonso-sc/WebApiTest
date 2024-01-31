using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using WebApiTest.EntityModels;

namespace WebApiTest.Services
{
    public class AuthService
    {
        private BillingTimeContext billingTimeContext;
        private IConfiguration configuration;

        public AuthService(
            BillingTimeContext _billingTimeContext,
            IConfiguration _configuration
        )
        {
            billingTimeContext = _billingTimeContext;
            configuration = _configuration;
        }


        internal bool CheckCredentials(string userName, string password)
        {
            User? user = billingTimeContext
                .Users
                .Where((u) => u.Name == userName)
                .Include((u) => u.Roles)
                .FirstOrDefault();

            return user != null & password == "Pass123";

        }

        internal string? GetToken(User user)
        {
            if (user == null) return null;

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user!.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user!.Name)
            };

            List<Role> userRoles = user.Roles.ToList();
            foreach (Role role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(5),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string? LogIn(string userName, string password)
        {

            if (CheckCredentials(userName, password))
            {
                User user = billingTimeContext
                    .Users
                    .Where((u) => u.Name == userName)
                    .Include((u) => u.Roles)
                    .FirstOrDefault()!;

                var token = GetToken(user!);
                return token;
            }

            return null;

        }


    }
}