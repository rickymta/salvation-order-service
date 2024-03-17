using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Handlers.Abstractions;
using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;
using Salvation.Services.OrderService.Services.Abstractions;

namespace Salvation.Services.OrderService.Handlers.Implementations;

public class VoucherHandler : IVoucherHandler
{
    private readonly IVoucherService _voucherService;

    private readonly ILogProvider _logProvider;

    public VoucherHandler(IVoucherService voucherService, ILogProvider logProvider)
    {
        _voucherService = voucherService;
        _logProvider = logProvider;
    }

    public async Task<string> CreateAsync(VoucherCreateRequest entity)
    {
        try
        {
            var res = await _voucherService.CreateAsync(entity);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return string.Empty;
        }
    }

    public async Task<bool> DeleteAsync(VoucherDeleteRequest request)
    {
        try
        {
            var res = await _voucherService.DeleteAsync(request);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return false;
        }
    }

    public async Task<DataPaging<Vouchers>?> FilterDataPagingAsync(VoucherFilter filter)
    {
        try
        {
            var res = await _voucherService.FilterDataPagingAsync(filter);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<IEnumerable<Vouchers>?> GetAllAsync()
    {
        try
        {
            var res = await _voucherService.GetAllAsync();
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<Vouchers?> GetAsync(string id)
    {
        try
        {
            var res = await _voucherService.GetAsync(id);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<bool> UpdateAsync(VoucherUpdateRequest entity)
    {
        try
        {
            var res = await _voucherService.UpdateAsync(entity);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return false;
        }
    }
}
