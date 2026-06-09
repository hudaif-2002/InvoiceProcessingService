using InvoiceProcessingService.Services;
using InvoiceProcessingService.DTOs;


using Microsoft.AspNetCore.Mvc;

namespace InvoiceProcessingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController :ControllerBase
    {

            private readonly IAuthService _authService;
            public AuthController(IAuthService authService)
            {
                _authService = authService;
            }

            [HttpPost("login")]
            public IActionResult Login([FromBody] LoginDto request)
            {
                var token = _authService.Authenticate(request.Username, request.Password);
                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(new { Token = token });
            }


        }

    
}
