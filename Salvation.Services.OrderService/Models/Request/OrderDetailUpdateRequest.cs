using Salvation.Services.OrderService.Models.Enums;
using Salvation.Services.OrderService.Models.Request.Base;

namespace Salvation.Services.OrderService.Models.Request;

public class OrderDetailUpdateRequest : UpdateRequestBase
{
    public string OrderId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string ProductFeatureImage { get; set; } = null!;

    public int ProductQuantity { get; set; }

    public double TotalPrice { get; set; }

    public int ProductSale { get; set; }

    public double TotalSalePrice { get; set; }

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public OrderStatus Status { get; set; }
}
