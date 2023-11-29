using Microsoft.AspNetCore.Mvc;
using N76_HomeTask.Application.Services;
using N76_HomeTask.Domain.Models;

namespace N76_HomeTask.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : Controller
{
    [HttpGet]
    public IActionResult GetAll() => Ok(userService.Get(user => true));
    [HttpGet("{id:}")]
    public IActionResult GetById([FromRoute] Guid id) => Ok(userService.Get(user => true));


    [HttpPost]
    public IActionResult Create([FromBody]User user)
    {
        return Ok(userService.CreateAsync(user,true));
    }

    [HttpPut]
    public IActionResult Update([FromBody] User user)
    {
        return Ok(userService.UpdateAsync(user));
    }
    [HttpDelete]
    public IActionResult Delete([FromBody] User user)
    {
        return Ok(userService.DeleteAsync(user));
    }
}