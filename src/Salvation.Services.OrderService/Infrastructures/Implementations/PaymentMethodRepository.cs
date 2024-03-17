using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Infrastructures.Abstractions;
using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Context;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;

namespace Salvation.Services.OrderService.Infrastructures.Implementations;

public class PaymentMethodRepository : GenericRepository<PaymentMethods>, IPaymentMethodRepository
{
    public PaymentMethodRepository(ApplicationDbContext context, ILogProvider logger) : base(context, logger)
    {
    }

    public Task<DataPaging<PaymentMethods>?> FilterDataPagingAsync(PaymentMethodFilter filter)
    {
        throw new NotImplementedException();
    }
}
