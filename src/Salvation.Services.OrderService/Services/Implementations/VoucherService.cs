using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Infrastructures.Abstractions;
using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;
using Salvation.Services.OrderService.Services.Abstractions;
using static Dapper.SqlMapper;

namespace Salvation.Services.OrderService.Services.Implementations;

public class VoucherService : IVoucherService
{
    private readonly IVoucherRepository _voucherRepository;

    private readonly ILogProvider _logProvider;

    public VoucherService(IVoucherRepository voucherRepository, ILogProvider logProvider)
    {
        _voucherRepository = voucherRepository;
        _logProvider = logProvider;
    }

    public async Task<string> CreateAsync(VoucherCreateRequest request)
    {
        try
        {
            var entity = new Vouchers
            {
                Id = request.Id,
                VoucherCode = request.VoucherCode,
                Quantity = request.Quantity,
                Sale = request.Sale,
                Status = request.Status,
                AdminId = request.AdminId,
                CreatedAt = request.CreatedAt
            };

            var res = await _voucherRepository.CreateAsync(entity);
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
            var res = await _voucherRepository.DeleteAsync(request.Id);
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
            var res = await _voucherRepository.FilterDataPagingAsync(filter);
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
            var res = await _voucherRepository.GetAllAsync();
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
            var res = await _voucherRepository.GetAsync(id);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<bool> UpdateAsync(VoucherUpdateRequest request)
    {
        try
        {
            var entity = await GetAsync(request.Id);

            if (entity != null)
            {
                entity.VoucherCode = request.VoucherCode;
                entity.Quantity = request.Quantity.Value;
                entity.Sale = request.Sale.Value;
                entity.Status = request.Status.Value;
                entity.AdminId = request.AdminId;
                entity.UpdatedAt = request.UpdatedAt;
                var res = await _voucherRepository.UpdateAsync(entity);
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
