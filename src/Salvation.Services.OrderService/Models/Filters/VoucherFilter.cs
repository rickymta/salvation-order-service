using Salvation.Services.OrderService.Models.Filters.Base;

namespace Salvation.Services.OrderService.Models.Filters;

public class VoucherFilter : FilterBase
{
    public string? VoucherCode { get; set; }

    public int? Sale { get; set; }

    public int? Quantity { get; set; }

    public int? AdminId { get; set; }

    public int? Status { get; set; }
}
