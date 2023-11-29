namespace N70HomeTask.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder.AddPersitense()
            .AddInfrastructure()
            .AddExposers()
            .AddDevTools();
        return new(builder);
    }
    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication builder)
    {
        builder
            .UseDevTools()
            .UseExposers();
        return new(builder);
    }
}