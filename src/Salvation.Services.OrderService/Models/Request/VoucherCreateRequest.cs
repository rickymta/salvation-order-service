using Salvation.Services.OrderService.Models.Request.Base;

namespace Salvation.Services.OrderService.Models.Request;

public class VoucherCreateRequest : CreateRequestBase
{
    public string VoucherCode { get; set; } = null!;

    public int Sale { get; set; }

    public int Quantity { get; set; }

    public string? AdminId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int Status { get; set; }
}
