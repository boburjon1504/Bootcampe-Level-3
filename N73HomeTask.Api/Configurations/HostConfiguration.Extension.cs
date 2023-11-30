using Microsoft.EntityFrameworkCore;
using N73HomeTask.Persistense.DataAccess;

namespace N73HomeTask.Api.Configurations;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddPersistense(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<NotificationDbContext>(option =>
            option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        return builder;
    }
}