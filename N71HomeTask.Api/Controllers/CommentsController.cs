using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N71HomeTask.Application.Sevices;
using N71HomeTask.Domain.Entities;

namespace N71HomeTask.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController(ICommentService commentService) : Controller
{
    [HttpGet]
    public IActionResult GetAll() => Ok(commentService
        .Get(c => true).Include(c => c.Comments));

    [HttpPost]
    public IActionResult Create([FromBody] Comment comment)
    {
        return Ok(commentService.CreateAsync(comment, true, HttpContext.RequestAborted));
    }
}