using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;

namespace Salvation.Services.OrderService.Infrastructures.Abstractions;

public interface IPaymentMethodRepository : IGenericRepository<PaymentMethods>
{
    Task<DataPaging<PaymentMethods>?> FilterDataPagingAsync(PaymentMethodFilter filter);
}
