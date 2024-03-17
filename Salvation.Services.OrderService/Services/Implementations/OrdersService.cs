using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Infrastructures.Abstractions;
using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;
using Salvation.Services.OrderService.Services.Abstractions;

namespace Salvation.Services.OrderService.Services.Implementations;

public class OrdersService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    private readonly ILogProvider _logProvider;

    private readonly IStringProvider _stringProvider;

    public OrdersService(IOrderRepository orderRepository, ILogProvider logProvider, IStringProvider stringProvider)
    {
        _orderRepository = orderRepository;
        _logProvider = logProvider;
        _stringProvider = stringProvider;
    }

    public async Task<string> CreateAsync(OrderCreateRequest request)
    {
        try
        {
            var randomString = _stringProvider.RandomString(6);
            var current = DateTime.UtcNow;
            var currentYear = current.ToString("yyyy");
            var currentDay = current.ToString("MMdd");
            var currentTime = current.ToString("HHmmssFFF");
            var orderCode = "SAL" + currentYear + request.TransportCode + currentDay + request.PaymentCode + currentTime + randomString;
            request.OrderCode = orderCode;

            var entity = new Orders
            {
                Id = request.Id,
                FullName = request.FullName,
                AccountId = request.AccountId,
                Address = request.Address,
                CreatedAt = request.CreatedAt,
                OrderCode = orderCode,
                PaymentCode = request.PaymentCode,
                PaymentId = request.PaymentId,
                PhoneNumber = request.PhoneNumber,
                Status = request.Status,
                TotalAmount = request.TotalAmount,
                TotalSale = request.TotalSale,
                TransportCode = request.TransportCode,
                TransportId = request.TransportId,
                VoucherId = request.VoucherId,
                VoucherSale = request.VoucherSale
            };

            var res = await _orderRepository.CreateAsync(entity);
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
            var res = await _orderRepository.DeleteAsync(request.Id);
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
            var res = await _orderRepository.FilterDataPagingAsync(filter);
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
            var res = await _orderRepository.GetAllAsync();
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
            var res = await _orderRepository.GetAsync(id);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<bool> UpdateAsync(OrderUpdateRequest request)
    {
        try
        {
            var entity = await GetAsync(request.Id);

            if (entity != null)
            {
                entity.FullName = request.FullName;
                entity.AccountId = request.AccountId;
                entity.Address = request.Address;
                entity.OrderCode = request.OrderCode;
                entity.PaymentCode = request.PaymentCode;
                entity.PaymentId = request.PaymentId;
                entity.PhoneNumber = request.PhoneNumber;
                entity.TotalAmount = request.TotalAmount.Value;
                entity.TotalSale = request.TotalSale.Value;
                entity.TransportCode = request.TransportCode;
                entity.TransportId = request.TransportId;
                entity.VoucherId = request.VoucherId;
                entity.VoucherSale = request.VoucherSale;
                entity.Status = request.Status.Value;
                var res = await _orderRepository.UpdateAsync(entity);
                return res;
            }
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
        }

        return false;
    }
}
