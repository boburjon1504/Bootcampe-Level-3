namespace N71HomeTask.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddPersistense()
            .AddBlogPostInfrastructures()
            .AddExposers()
            .AddDevTools();
        return new(builder);
    }
    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseDevTools()
            .UseExposers();
        return new(app);
    }
}