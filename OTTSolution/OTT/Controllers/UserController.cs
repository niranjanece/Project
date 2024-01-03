using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTT.Interfaces;
using OTT.Models.DTOs;

namespace OTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public ActionResult Register(UserRegisterDTO userDTO)
        {
            var user = _userService.Register(userDTO);
            if(user != null) 
            { 
                return Ok(user);
            }
            return BadRequest("Could not register user");
        }

        [HttpPost("Login")]
        public ActionResult Login(UserDTO userDTO)
        {
            var user = _userService.Login(userDTO);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest("Invalid username or password");
        }
    }
}
