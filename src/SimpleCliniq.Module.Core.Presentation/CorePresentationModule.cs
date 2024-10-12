using Microsoft.Extensions.DependencyInjection;
using Simple.Common.Presentation.Endpoints;

namespace SimpleCliniq.Module.Core.Presentation;

public static class CorePresentationModule
{
    public static IServiceCollection AddCorePresentationModule(
        this IServiceCollection services)
    {
        services.AddEndpoints(AssemblyReference.Assembly);

        return services;
    }
}
