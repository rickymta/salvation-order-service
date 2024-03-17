using Salvation.Services.OrderService.Handlers.Abstractions;
using Salvation.Services.OrderService.Handlers.Implementations;

namespace Salvation.Services.OrderService.Handlers;

public static class HandlerRegister
{
    public static void RegisterHandlers(this IServiceCollection services)
    {
        services.AddTransient<IOrderDetailHandler, OrderDetailHandler>();
        services.AddTransient<IOrderHandler, OrderHandler>();
        services.AddTransient<IPaymentMethodHandler, PaymentMethodHandler>();
        services.AddTransient<ITransportHandler, TransportHandler>();
        services.AddTransient<IVoucherHandler, VoucherHandler>();
    }
}
