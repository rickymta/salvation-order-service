using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Handlers.Abstractions;
using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;
using Salvation.Services.OrderService.Services.Abstractions;

namespace Salvation.Services.OrderService.Handlers.Implementations;

public class OrderHandler : IOrderHandler
{
    private readonly IOrderService _orderService;

    private readonly ILogProvider _logProvider;

    public OrderHandler(IOrderService orderService, ILogProvider logProvider)
    {
        _orderService = orderService;
        _logProvider = logProvider;
    }

    public async Task<string> CreateAsync(OrderCreateRequest entity)
    {
        try
        {
            var res = await _orderService.CreateAsync(entity);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return string.Empty;
        }
    }

    public async Task<bool> DeleteAsync(OrderDeleteRequest request)
    {
        try
        {
            var res = await _orderService.DeleteAsync(request);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return false;
        }
    }

    public async Task<DataPaging<Orders>?> FilterDataPagingAsync(OrderFilter filter)
    {
        try
        {
            var res = await _orderService.FilterDataPagingAsync(filter);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<IEnumerable<Orders>?> GetAllAsync()
    {
        try
        {
            var res = await _orderService.GetAllAsync();
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<Orders?> GetAsync(string id)
    {
        try
        {
            var res = await _orderService.GetAsync(id);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<bool> UpdateAsync(OrderUpdateRequest entity)
    {
        try
        {
            var res = await _orderService.UpdateAsync(entity);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return false;
        }
    }
}
