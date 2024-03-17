using Salvation.Services.OrderService.Services.Abstractions;
using Salvation.Services.OrderService.Services.Implementations;

namespace Salvation.Services.OrderService.Services;

public static class ServiceRegister
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IOrderDetailService, OrderDetailService>();
        services.AddTransient<IOrderService, OrdersService>();
        services.AddTransient<IPaymentMethodService, PaymentMethodService>();
        services.AddTransient<ITransportService, TransportService>();
        services.AddTransient<IVoucherService, VoucherService>();
    }
}
