using agrconclude.API.DTOs.Response;
using agrconclude.Application.DTOs.Request;
using agrconclude.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace agrconclude.API.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var result = await _authService.LoginAsync<LoginRequest, LoginResponse>(request);
            return Ok(result);
        }
    }
}