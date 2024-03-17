using Salvation.Services.OrderService.Models.Request.Base;

namespace Salvation.Services.OrderService.Models.Request;

public class TransportUpdateRequest : UpdateRequestBase
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public double? Price { get; set; }

    public string? AdminId { get; set; }

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public int? Status { get; set; }
}
