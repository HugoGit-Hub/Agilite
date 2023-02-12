using Microsoft.Extensions.DependencyInjection;

namespace Agilite.Mapper.Configuration;

public static class Configuration
{
    public static IServiceCollection ConfigureMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(AssemblyMarker.Assembly);
        return services;
    }
}