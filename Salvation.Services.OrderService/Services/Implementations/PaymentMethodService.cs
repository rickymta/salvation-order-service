using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Infrastructures.Abstractions;
using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;
using Salvation.Services.OrderService.Services.Abstractions;

namespace Salvation.Services.OrderService.Services.Implementations;

public class PaymentMethodService : IPaymentMethodService
{
    private readonly IPaymentMethodRepository _paymentMethodRepository;

    private readonly ILogProvider _logProvider;

    public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository, ILogProvider logProvider)
    {
        _paymentMethodRepository = paymentMethodRepository;
        _logProvider = logProvider;
    }

    public async Task<string> CreateAsync(PaymentMethodCreateRequest request)
    {
        try
        {
            var entity = new PaymentMethods
            {
                Id = request.Id,
                AdminId = request.AdminId,
                Code = request.Code,
                CreatedAt = DateTime.UtcNow,
                Description = request.Description,
                Name = request.Name,
                Status = request.Status
            };

            var res = await _paymentMethodRepository.CreateAsync(entity);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return string.Empty;
        }
    }

    public async Task<bool> DeleteAsync(PaymentMethodDeleteRequest request)
    {
        try
        {
            var res = await _paymentMethodRepository.DeleteAsync(request.Id);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return false;
        }
    }

    public async Task<DataPaging<PaymentMethods>?> FilterDataPagingAsync(PaymentMethodFilter filter)
    {
        try
        {
            var res = await _paymentMethodRepository.FilterDataPagingAsync(filter);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<IEnumerable<PaymentMethods>?> GetAllAsync()
    {
        try
        {
            var res = await _paymentMethodRepository.GetAllAsync();
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<PaymentMethods?> GetAsync(string id)
    {
        try
        {
            var res = await _paymentMethodRepository.GetAsync(id);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<bool> UpdateAsync(PaymentMethodUpdateRequest request)
    {
        try
        {
            var entity = await GetAsync(request.Id);

            if (entity != null)
            {
                entity.AdminId = request.AdminId;
                entity.Status = request.Status.Value;
                entity.Code = request.Code;
                entity.UpdatedAt = DateTime.UtcNow;
                entity.Description = request.Description;
                entity.Name = request.Name;
                var res = await _paymentMethodRepository.UpdateAsync(entity);
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
