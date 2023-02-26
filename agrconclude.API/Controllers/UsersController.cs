using agrconclude.Application.DTOs;
using agrconclude.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace agrconclude.API.Controllers;

public class UsersController : FacadeController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [Authorize]
    [HttpGet("api/v1/users")]
    public async Task<IActionResult> GetUsersAsync()
    {
        var users = await _userService.GetUsersAsync<IEnumerable<AppUserDTO>>(UserId);
        return Ok(users);
    }
}