using Salvation.Services.OrderService.Models.Request.Base;

namespace Salvation.Services.OrderService.Models.Request;

public class VoucherUpdateRequest : UpdateRequestBase
{
    public string? VoucherCode { get; set; }

    public int? Sale { get; set; }

    public int? Quantity { get; set; }

    public string? AdminId { get; set; }

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public int? Status { get; set; }
}
