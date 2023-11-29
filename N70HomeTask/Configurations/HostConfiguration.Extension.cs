using System.Collections.Immutable;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using N70HomeTask.Application.Service;
using N70HomeTask.Infrastructure.Common.Settings;
using N70HomeTask.Infrastructure.Service;
using N70HomeTask.Persistense.DataAccess;
using N70HomeTask.Persistense.Repositories.RoleRepositories;
using N70HomeTask.Persistense.Repositories.UserRepositories;

namespace N70HomeTask.Configurations;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddPersitense(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));
        builder.Services
            .AddScoped<IUserRespository, UserRepository>()
            .AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddDbContext<Identity>(option =>
            option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnention")));
        return builder;
    }
    private static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<ITokenGeneratorService,TokenGeneratorService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IRoleService, RoleService>()
            .AddScoped<IAuthService, AuthService>();
        var jwtToken = new JwtSettings();

        builder.Configuration.GetSection(nameof(JwtSettings)).Bind(jwtToken);
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(option =>
            {
                var token = new TokenValidationParameters
                {
                    ValidateAudience = jwtToken.ValidateAudience,
                    ValidAudience = jwtToken.ValidAudience,
                    ValidIssuer = jwtToken.ValidIssuer,
                    ValidateIssuer = jwtToken.ValidateAudience,
                    ValidateLifetime = jwtToken.ValidateLifeTime,
                    ValidateIssuerSigningKey = jwtToken.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtToken.SecretKey))
                };
            });
        return builder;
    }
    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddRouting(route=>route.LowercaseUrls = true)
            .AddControllers();
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