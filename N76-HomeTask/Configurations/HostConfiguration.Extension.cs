using Microsoft.EntityFrameworkCore;
using N76_HomeTask.Application.Services;
using N76_HomeTask.Infrastructure.Services;
using N76_HomeTask.Persistense.DataAccess;
using N76_HomeTask.Persistense.Intersepters;
using N76_HomeTask.Persistense.Repositories;

namespace N76_HomeTask.Configurations;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddInfratructures(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IBookRepository, BookRepository>()
            .AddScoped<IBookService, BookService>();
        return builder;
    }

    private static WebApplicationBuilder AddPersistense(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<CreateAuditableInterceptor>();
        builder.Services.AddDbContext<AppDbContext>((provider, options) =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            options.AddInterceptors(provider.CreateScope().ServiceProvider
                .GetRequiredService<CreateAuditableInterceptor>());
        });
        return builder;
    }

    private static WebApplicationBuilder AddExposer(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(rout => rout.LowercaseUrls = true);
        builder.Services.AddControllers();
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

    private static WebApplication UseExposer(this WebApplication app)
    {
        app.MapControllers();
        return app;
    }
}