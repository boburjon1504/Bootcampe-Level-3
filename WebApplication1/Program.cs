using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(o=>o
    .UseNpgsql("Host=localhost;Port=5432;Database=IncludePracitce;Username=postgres;Password=boburjon6767"));


builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("api/users", ([FromServices] AppDbContext context) =>
{
    return context.Users.AsQueryable().Include(user=>user.Books);
});

app.MapPost("api/users", async ([FromBody] User user, [FromServices] AppDbContext context)=>
{
    user.Id = Guid.Empty;
    var usr = await context.Users.AddAsync(user);

    await context.SaveChangesAsync();

    return usr.Entity;
});
app.MapPost("api/books", async ([FromBody] Book user, [FromServices] AppDbContext context)=>
{
    user.Id = Guid.Empty;
    var usr = await context.Books.AddAsync(user);

    await context.SaveChangesAsync();

    return usr.Entity;
});



app.Run();

