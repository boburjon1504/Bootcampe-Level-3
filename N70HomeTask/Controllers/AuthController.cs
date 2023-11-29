using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N70HomeTask.Application.Service;
using N70HomeTask.Domain.Entities;
using N70HomeTask.Domain.Enums;

namespace N70HomeTask.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService,IUserService userService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(userService.Get(x => true));
    [HttpPost("register")]
    public IActionResult SignUp([FromBody] User user)
    {
        return Ok(authService.RegisterAsync(user,true,HttpContext.RequestAborted));
    }

    [HttpPost("login")]
    public IActionResult SingIn([FromBody] User user)
    {
        return Ok(authService.LoginAsync(user, true, HttpContext.RequestAborted));
    }
    [Authorize(Roles = "Admin")]
    [HttpPut("{userId:guid}")]
    public IActionResult GrandRole([FromRoute] Guid userId, UserRole role)
    {
        return Ok(authService.GrandRoleAsync(userId, role, true, HttpContext.RequestAborted));
    }
}