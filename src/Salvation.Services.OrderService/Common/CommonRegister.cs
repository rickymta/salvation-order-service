using Salvation.Core.Common.Implementations;
using Salvation.Services.OrderService.Common.Abstractions;

namespace Salvation.Services.OrderService.Common;

/// <summary>
/// ProviderRegister
/// </summary>
public static class CommonRegister
{
    /// <summary>
    /// AddProviderServices
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterProviders(this IServiceCollection services)
    {
        services.AddTransient<ILogProvider, LogProvider>();
        services.AddTransient<IStringProvider, StringProvider>();
    }
}
