using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;

namespace Salvation.Services.OrderService.Handlers.Abstractions;

public interface IOrderDetailHandler : IGenericHandler<OrderDetails, OrderDetailFilter, OrderDetailCreateRequest, OrderDetailUpdateRequest, OrderDetailDeleteRequest>
{
}
