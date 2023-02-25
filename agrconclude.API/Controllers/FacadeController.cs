using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace agrconclude.API.Controllers;

public class FacadeController : ControllerBase
{
    public Guid UserId => GetUserId();

    private Guid GetUserId()
    {
        var id = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.Parse(id!);
    }
}