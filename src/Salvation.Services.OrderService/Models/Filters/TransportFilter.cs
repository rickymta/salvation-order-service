using Salvation.Services.OrderService.Models.Filters.Base;

namespace Salvation.Services.OrderService.Models.Filters;

public class TransportFilter : FilterBase
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }

    public string? AdminId { get; set; }
}
