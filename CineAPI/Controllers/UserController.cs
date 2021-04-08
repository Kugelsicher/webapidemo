using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GlobalModels;

namespace CineAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userLogic;
        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpGet]
        public User Get()
        {
            return new User("Uname", "MrU", "Name", "mruname@gmail.com", 1);
        }

        [HttpGet("{username}")]
        public ActionResult<User> GetUser(string username)
        {
            if(!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            return _userLogic.GetUser(username);
        }
    }
}
