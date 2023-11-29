using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N71HomeTask.Application.Sevices;
using N71HomeTask.Domain.Entities;

namespace N71HomeTask.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PostsController(IPostService postService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(postService
        .Get(p => true));

    [HttpPost]
    public IActionResult Create([FromBody] Post post)
    {
        return Ok(postService.CreateAsync(post, true, HttpContext.RequestAborted));
    }
}