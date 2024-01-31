using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTest.EntityModels;
using WebApiTest.Models.DTO;
using WebApiTest.Services;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserService userService;
        public UserController(UserService _userService)
        {
            userService = _userService;
        }

        [HttpGet("List")]
        public ActionResult<List<User>> List()
        {
            return Ok(userService.getAllUsers());
        }

        [HttpGet("ById")]
        public ActionResult<User> ById(int Id)
        {
            return Ok(userService.getUserById(Id));
        }

        [HttpGet("ByEmail")]
        public ActionResult<User> ByEmail(string emailAddress)
        {
            return Ok(userService.getUserByEmailAddress(emailAddress));
        }

        [HttpPost("Add")]
        public ActionResult<User> AddBook(UserDto userToAdd)
        {
            return Ok(userService.addUser(userToAdd));
        }

        [HttpDelete("Delete")]
        public ActionResult<bool> Delete(DeleteUserRequestDto userToDelete)
        {
            return Ok(userService.deleteUser(userToDelete));
        }

        [HttpPut("UpdateUser")]
        public ActionResult<User> Update(UserDto userToUpdate)
        {
            return Ok(userService.updateUser(userToUpdate));
        }
    }
}