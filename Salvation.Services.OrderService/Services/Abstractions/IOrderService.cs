using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;

namespace Salvation.Services.OrderService.Services.Abstractions;

public interface IOrderService : IGenericService<Orders, OrderFilter, OrderCreateRequest, OrderUpdateRequest, OrderDeleteRequest>
{
}
