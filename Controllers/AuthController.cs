using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Services;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private AuthService authService;
        public AuthController(AuthService _authService)
        {
            authService = _authService;
        }

        [AllowAnonymous]
        [HttpPost("LogIn")]
        public ActionResult LogIn(string userName, string password)

        {
            var token = authService.LogIn(userName, password);
            if (token != null)
            {
                return Ok(new { token = token! });
            }
            return BadRequest("Incorrect name and password");
        }

    }
}