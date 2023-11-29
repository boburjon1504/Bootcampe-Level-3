using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N71HomeTask.Application.Sevices;
using N71HomeTask.Domain.Entities;

namespace N71HomeTask.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(userService.
        Get(user => true,true).ToListAsync());

    [HttpPost]
    public IActionResult Create([FromBody] User user)
    {
        return Ok(userService.CreateAsync(user, true, HttpContext.RequestAborted));
    }
}