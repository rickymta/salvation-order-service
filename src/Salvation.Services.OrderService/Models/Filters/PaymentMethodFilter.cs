using Salvation.Services.OrderService.Models.Filters.Base;

namespace Salvation.Services.OrderService.Models.Filters;

public class PaymentMethodFilter : FilterBase
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? AdminId { get; set; }
}
