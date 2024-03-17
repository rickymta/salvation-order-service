using Salvation.Services.OrderService.Infrastructures.Abstractions;
using Salvation.Services.OrderService.Infrastructures.Implementations;

namespace Salvation.Services.OrderService.Infrastructures;

public static class InfrastructureRegister
{
    public static void RegisterInfrastructures(this IServiceCollection services)
    {
        services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();
        services.AddTransient<ITransportRepository, TransportRepository>();
        services.AddTransient<IVoucherRepository, VoucherRepository>();
    }
}
