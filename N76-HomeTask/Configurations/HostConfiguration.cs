namespace N76_HomeTask.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddPersistense()
            .AddInfratructures()
            .AddExposer()
            .AddDevTools();
            
        return new(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseDevTools()
            .UseExposer();
        return new(app);
    }
}