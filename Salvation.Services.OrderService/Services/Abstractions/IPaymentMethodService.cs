using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;

namespace Salvation.Services.OrderService.Services.Abstractions;

public interface IPaymentMethodService : IGenericService<PaymentMethods, PaymentMethodFilter, PaymentMethodCreateRequest, PaymentMethodUpdateRequest, PaymentMethodDeleteRequest>
{
}
