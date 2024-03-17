using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;

namespace Salvation.Services.OrderService.Infrastructures.Abstractions;

public interface IOrderDetailRepository : IGenericRepository<OrderDetails>
{
    Task<DataPaging<OrderDetails>?> FilterDataPagingAsync(OrderDetailFilter filter);
}
