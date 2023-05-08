using agrconclude.Application.DTOs;
using agrconclude.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace agrconclude.API.Controllers;

[Route("api/v1/users")]
[Authorize]
public class UsersController : FacadeController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("api/v1/users")]
    public async Task<IActionResult> GetUsersAsync()
    {
        var users = await _userService.GetUsersAsync<IEnumerable<AppUserDTO>>(UserId);
        return Ok(users);
    }

    [HttpGet("/api/v1/profile")]
    public async Task<IActionResult> GetProfileAsync()
    {
        var result = await _userService.GetProfile(UserId);

        return Ok(result);
    }
}