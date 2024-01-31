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

        [HttpGet()]
        public ActionResult<List<User>> List(int page = 1, int pageCount = 20)
        {
            return Ok(userService.getAllUsers(page, pageCount));
        }

        [HttpGet("{Id}")]
        public ActionResult<User> ById(int Id)
        {
            return Ok(userService.getUserById(Id));
        }

        [HttpGet("ByEmail")]
        public ActionResult<User> ByEmail(string emailAddress)
        {
            return Ok(userService.getUserByEmailAddress(emailAddress));
        }

        [HttpPost()]
        public ActionResult<User> AddBook(UserDto userToAdd)
        {
            return Ok(userService.addUser(userToAdd));
        }

        [HttpDelete()]
        public ActionResult<bool> Delete(DeleteUserRequestDto userToDelete)
        {
            return Ok(userService.deleteUser(userToDelete));
        }

        [HttpPut()]
        public ActionResult<User> Update(UserDto userToUpdate)
        {
            return Ok(userService.updateUser(userToUpdate));
        }
    }
}