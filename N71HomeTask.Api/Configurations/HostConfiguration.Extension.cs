using Microsoft.EntityFrameworkCore;
using N71HomeTask.Application.Sevices;
using N71HomeTask.Infrastructure.Services;
using N71HomeTask.Persistense.DataAccess;
using N71HomeTask.Persistense.Repositories.CommentRepositores;
using N71HomeTask.Persistense.Repositories.PostRepositories;
using N71HomeTask.Persistense.Repositories.UserRepositories;

namespace N71HomeTask.Api.Configurations;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddPersistense(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
            options
                .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IPostRepository, PostRepository>()
            .AddScoped<ICommentRepository, CommentRepository>();
        return builder;
    }
    private static WebApplicationBuilder AddBlogPostInfrastructures(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<IUserService, UserService>()
            .AddScoped<IPostService, PostService>()
            .AddScoped<ICommentService, CommentService>();
        return builder;
    }
    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddRouting(x => x.LowercaseUrls = true);

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddSwaggerGen()
            .AddEndpointsApiExplorer();
        
        return builder;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app
            .UseSwagger()
            .UseSwaggerUI();
        
        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();
        return app;
    }
}