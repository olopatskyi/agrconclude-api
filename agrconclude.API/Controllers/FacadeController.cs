using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace agrconclude.API.Controllers;

public class FacadeController : ControllerBase
{
    public string UserId => GetUserId();

    private string GetUserId()
    {
        var id = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        return id!;
    }
}