using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;

namespace Salvation.Services.OrderService.Services.Abstractions;

public interface IVoucherService : IGenericService<Vouchers, VoucherFilter, VoucherCreateRequest, VoucherUpdateRequest, VoucherDeleteRequest>
{
}
