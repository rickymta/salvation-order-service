using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Infrastructures.Abstractions;
using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;
using Salvation.Services.OrderService.Services.Abstractions;

namespace Salvation.Services.OrderService.Services.Implementations;

public class OrderDetailService : IOrderDetailService
{
    private readonly IOrderDetailRepository _orderDetailRepository;

    private readonly ILogProvider _logProvider;

    public OrderDetailService(IOrderDetailRepository orderDetailRepository, ILogProvider logProvider)
    {
        _orderDetailRepository = orderDetailRepository;
        _logProvider = logProvider;
    }

    public async Task<string> CreateAsync(OrderDetailCreateRequest request)
    {
        try
        {
            var entity = new OrderDetails
            {
                Id = request.Id,
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                ProductQuantity = request.ProductQuantity,
                ProductFeatureImage = request.ProductFeatureImage,
                ProductSale = request.ProductSale,
                Status = request.Status,
                TotalPrice = request.TotalPrice,
                TotalSalePrice = request.TotalSalePrice,
                CreatedAt = request.CreatedAt
            };

            var res = await _orderDetailRepository.CreateAsync(entity);
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
            var res = await _orderDetailRepository.DeleteAsync(request.Id);
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
            var res = await _orderDetailRepository.FilterDataPagingAsync(filter);
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
            var res = await _orderDetailRepository.GetAllAsync();
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
            var res = await _orderDetailRepository.GetAsync(id);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<bool> UpdateAsync(OrderDetailUpdateRequest request)
    {
        try
        {
            var entity = await GetAsync(request.Id);
            
            if (entity != null)
            {
                entity.OrderId = request.OrderId;
                entity.ProductId = request.ProductId;
                entity.ProductName = request.ProductName;
                entity.ProductSale = request.ProductSale;
                entity.ProductQuantity = request.ProductQuantity;
                entity.ProductFeatureImage = request.ProductFeatureImage;
                entity.Status = request.Status;
                entity.TotalSalePrice = request.TotalSalePrice;
                entity.UpdatedAt = request.UpdatedAt;
                var res = await _orderDetailRepository.UpdateAsync(entity);
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
