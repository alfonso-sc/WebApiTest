using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApiTest.EntityModels;
using WebApiTest.Models.DTO;

namespace WebApiTest.Services
{
    public class UserService
    {
        private BillingTimeContext billingTimeContext;
        private IConfiguration configuration;

        public UserService(
            BillingTimeContext _billingTimeContext,
            IConfiguration _configuration
            )
        {
            billingTimeContext = _billingTimeContext;
            configuration = _configuration;
        }

        public List<User> getAllUsers(int page, int pageCount, string orderBy, bool ascending)
        {
            int skip = (page - 1) * pageCount;

            var query = billingTimeContext
                .Users
                .Include((u) => u.Roles)
                .Include((u) => u.Projects)
                .AsQueryable();

            switch (orderBy)
            {
                case "name":
                    query =
                        ascending ?
                            query.OrderBy((u) => u.Name) :
                            query.OrderByDescending((u) => u.Name);
                    break;
                case "email":
                    query =
                        ascending ?
                        query.OrderBy((u) => u.Email) :
                        query.OrderByDescending((u) => u.Email);
                    break;
                case "id":
                default:
                    query =
                        ascending ?
                        query.OrderBy((u) => u.Id) :
                        query.OrderByDescending((u) => u.Id);
                    break;

            }

            return query
                .Skip(skip)
                .Take(pageCount)
                .ToList();
        }

        public User? getUserById(int Id)
        {
            return billingTimeContext
                .Users
                .Where(user => user.Id == Id)
                .Include((u) => u.Roles)
                .Include((u) => u.Projects)
                .FirstOrDefault();
        }

        public User? getUserByEmailAddress(string emailAddress)
        {
            return billingTimeContext
                .Users
                .Where((u) => u.Email == emailAddress)
                .Include((u) => u.Roles)
                .Include((u) => u.Projects)
                .FirstOrDefault();
        }

        public User addUser(UserDto userToAdd)
        {
            var newDbUser = new User()
            {
                Name = userToAdd.Name,
                Email = userToAdd.Email,
                ManagerId = userToAdd.ManagerId,
                ExpectedHours = userToAdd.ExpectedHours,
                Active = userToAdd.Active,
                PhoneNumber = userToAdd.PhoneNumber,
                Projects = billingTimeContext.Projects.Where((p) => userToAdd.ProjectIds.Contains(p.Id)).ToList(),
                Roles = billingTimeContext.Roles.Where((r) => userToAdd.Roles.Contains(r.Name)).ToList()
            };
            billingTimeContext.Add(newDbUser);
            billingTimeContext.SaveChanges();
            return newDbUser;
        }

        public bool deleteUser(DeleteUserRequestDto userToDelete)
        {
            var existingUser =
                billingTimeContext
                .Users
                .Include((u) => u.Roles)
                .Include((u) => u.Projects)
                .Include((u) => u.FavoritesXrefs)
                .Include((u) => u.Entries)
                .FirstOrDefault((u) => u.Id == userToDelete.Id);

            if (existingUser != null)
            {
                existingUser.Roles.Clear();
                existingUser.Projects.Clear();
                billingTimeContext.FavoritesXrefs.RemoveRange(existingUser.FavoritesXrefs);
                billingTimeContext.Entries.RemoveRange(existingUser.Entries);
                billingTimeContext.Users.Remove(existingUser);
                billingTimeContext.SaveChanges();
                return true;
            }
            return false;
        }

        public User updateUser(UserDto userToUpdate)
        {
            var updatedDbUser = new User()
            {
                Id = userToUpdate.Id!.Value,
                Name = userToUpdate.Name,
                Email = userToUpdate.Email,
                ManagerId = userToUpdate.ManagerId,
                ExpectedHours = userToUpdate.ExpectedHours,
                Active = userToUpdate.Active,
                PhoneNumber = userToUpdate.PhoneNumber,
                Projects = billingTimeContext.Projects.Where((p) => userToUpdate.ProjectIds.Contains(p.Id)).ToList(),
                Roles = billingTimeContext.Roles.Where((r) => userToUpdate.Roles.Contains(r.Name)).ToList()
            };
            billingTimeContext.Update(updatedDbUser);
            billingTimeContext.SaveChanges();
            return updatedDbUser;
        }

        public string GetToken()
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Username@user.com"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, "Username")
            };

            authClaims.Add(new Claim(ClaimTypes.Role, "Admin"));


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

    }
}
