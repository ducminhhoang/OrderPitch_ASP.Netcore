using Microsoft.AspNetCore.Mvc;
using TestApiPitchOrder.Services;
using TestApiPitchOrder.Models;
using TestApiPitchOrder.DTOs;

namespace TestApiPitchOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AccountDTO account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _authService.LoginAsync(account);

            if (token == null)
            {
                return Unauthorized(new { Message = "Invalid login attempt" });
            }

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _authService.RegisterAsync(account);

            if (!success)
            {
                return Conflict(new { Message = "Email already exists" });
            }

            return Ok(new { Message = "Registration successful" });
        }
    }
}
