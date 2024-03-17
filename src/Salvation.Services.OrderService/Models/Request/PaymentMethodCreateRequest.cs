using Salvation.Services.OrderService.Models.Request.Base;

namespace Salvation.Services.OrderService.Models.Request;

public class PaymentMethodCreateRequest : CreateRequestBase
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string? AdminId { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public int Status { get; set; }
}
