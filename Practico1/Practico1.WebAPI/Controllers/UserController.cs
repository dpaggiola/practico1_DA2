using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practico1.Domain;
using Practico1.IBusinessLogic;

namespace Practico1.WebAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IQueryable<User> users = _userService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Add([FromBody] User user)
        {
            User userCreated = _userService.Create(user);
            return Created("", userCreated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}

