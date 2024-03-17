using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Handlers.Abstractions;
using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;
using Salvation.Services.OrderService.Services.Abstractions;

namespace Salvation.Services.OrderService.Handlers.Implementations;

public class PaymentMethodHandler : IPaymentMethodHandler
{
    private readonly IPaymentMethodService _paymentMethodService;

    private readonly ILogProvider _logProviderProvider;

    public PaymentMethodHandler(IPaymentMethodService paymentMethodService, ILogProvider loggerProvider)
    {
        _paymentMethodService = paymentMethodService;
        _logProviderProvider = loggerProvider;
    }

    public async Task<string> CreateAsync(PaymentMethodCreateRequest entity)
    {
        try
        {
            var res = await _paymentMethodService.CreateAsync(entity);
            return res;
        }
        catch (Exception ex)
        {
            _logProviderProvider.Error(ex);
            return string.Empty;
        }
    }

    public async Task<bool> DeleteAsync(PaymentMethodDeleteRequest request)
    {
        try
        {
            var res = await _paymentMethodService.DeleteAsync(request);
            return res;
        }
        catch (Exception ex)
        {
            _logProviderProvider.Error(ex);
            return false;
        }
    }

    public async Task<DataPaging<PaymentMethods>?> FilterDataPagingAsync(PaymentMethodFilter filter)
    {
        try
        {
            var res = await _paymentMethodService.FilterDataPagingAsync(filter);
            return res;
        }
        catch (Exception ex)
        {
            _logProviderProvider.Error(ex);
            return null;
        }
    }

    public async Task<IEnumerable<PaymentMethods>?> GetAllAsync()
    {
        try
        {
            var res = await _paymentMethodService.GetAllAsync();
            return res;
        }
        catch (Exception ex)
        {
            _logProviderProvider.Error(ex);
            return null;
        }
    }

    public async Task<PaymentMethods?> GetAsync(string id)
    {
        try
        {
            var res = await _paymentMethodService.GetAsync(id);
            return res;
        }
        catch (Exception ex)
        {
            _logProviderProvider.Error(ex);
            return null;
        }
    }

    public async Task<bool> UpdateAsync(PaymentMethodUpdateRequest entity)
    {
        try
        {
            var res = await _paymentMethodService.UpdateAsync(entity);
            return res;
        }
        catch (Exception ex)
        {
            _logProviderProvider.Error(ex);
            return false;
        }
    }
}
