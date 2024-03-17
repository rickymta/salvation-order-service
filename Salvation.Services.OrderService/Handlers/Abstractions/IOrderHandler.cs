using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;

namespace Salvation.Services.OrderService.Handlers.Abstractions;

public interface IOrderHandler : IGenericHandler<Orders, OrderFilter, OrderCreateRequest, OrderUpdateRequest, OrderDeleteRequest>
{
}
