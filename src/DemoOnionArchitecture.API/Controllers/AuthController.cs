
using DemoOnionArchitecture.Application.Abstract;
using DemoOnionArchitecture.Application.DTOs.Request;
using DemoOnionArchitecture.Application.DTOs.Response;
using DemoOnionArchitecture.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestVM model)
        {
            LoginResponseVM response = await _userService.Login(model);
            if (response.Users == null)
            {
                return BadRequest(response);
            }
            else
            {
                response.Users.PasswordHash = "";
                return Ok(response);
            }
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestVM model)
        {
            User user = await _userService.Register(model);
            if (user == null)
            {
                return BadRequest();
            }
            user.PasswordHash = "";
            return Ok(user);
        }
    }
}
