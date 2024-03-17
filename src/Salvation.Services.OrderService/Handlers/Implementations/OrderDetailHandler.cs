using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Handlers.Abstractions;
using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;
using Salvation.Services.OrderService.Services.Abstractions;

namespace Salvation.Services.OrderService.Handlers.Implementations;

public class OrderDetailHandler : IOrderDetailHandler
{
    private readonly ILogProvider _logProvider;

    private readonly IOrderDetailService _orderDetailService;

    public OrderDetailHandler(ILogProvider logProvider, IOrderDetailService orderDetailService)
    {
        _logProvider = logProvider;
        _orderDetailService = orderDetailService;
    }

    public async Task<string> CreateAsync(OrderDetailCreateRequest entity)
    {
        try
        {
            var res = await _orderDetailService.CreateAsync(entity);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return string.Empty;
        }
    }

    public async Task<bool> DeleteAsync(OrderDetailDeleteRequest request)
    {
        try
        {
            var res = await _orderDetailService.DeleteAsync(request);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return false;
        }
    }

    public async Task<DataPaging<OrderDetails>?> FilterDataPagingAsync(OrderDetailFilter filter)
    {
        try
        {
            var res = await _orderDetailService.FilterDataPagingAsync(filter);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<IEnumerable<OrderDetails>?> GetAllAsync()
    {
        try
        {
            var res = await _orderDetailService.GetAllAsync();
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<OrderDetails?> GetAsync(string id)
    {
        try
        {
            var res = await _orderDetailService.GetAsync(id);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<bool> UpdateAsync(OrderDetailUpdateRequest entity)
    {
        try
        {
            var res = await _orderDetailService.UpdateAsync(entity);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return false;
        }
    }
}
