using InvoiceProcessingService.Services;
using InvoiceProcessingService.DTOs;


using Microsoft.AspNetCore.Mvc;

namespace InvoiceProcessingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto request)
        {
            var token = _authService.LoginAsync(request);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto request)
        {
            var result = await _authService.RegisterAsync(request);
            if (!result)
            {
                return BadRequest("User already exists.");
            }
            return Ok("User registered successfully.");


        }


    }
}

