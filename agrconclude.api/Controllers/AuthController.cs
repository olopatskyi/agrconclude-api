using agrconclude.api.DTOs.Request;
using agrconclude.api.DTOs.Response;
using agrconclude.core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace agrconclude.api.Controllers
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