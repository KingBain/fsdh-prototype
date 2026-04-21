using Microsoft.Extensions.DependencyInjection;

namespace Datahub.Portal.Standalone.Services;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStandaloneScaffolding(this IServiceCollection services)
    {
        services.AddSingleton<IStandaloneModeService, StandaloneModeService>();
        return services;
    }
}
