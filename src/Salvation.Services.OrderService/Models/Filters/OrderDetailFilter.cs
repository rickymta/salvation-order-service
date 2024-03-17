using Salvation.Services.OrderService.Models.Enums;
using Salvation.Services.OrderService.Models.Filters.Base;

namespace Salvation.Services.OrderService.Models.Filters;

public class OrderDetailFilter : FilterBase
{
    public string? OrderId { get; set; }

    public string? ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductFeatureImage { get; set; }

    public int? ProductQuantity { get; set; }

    public double? TotalPrice { get; set; }

    public int? ProductSale { get; set; }

    public double? TotalSalePrice { get; set; }

    public DateTime? CreateStartDate { get; set; }

    public DateTime? CreateEndDate { get; set; }

    public OrderStatus? Status { get; set; }
}
