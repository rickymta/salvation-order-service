using Salvation.Services.OrderService.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salvation.Services.OrderService.Models.Entities;

[Table("order_details")]
public class OrderDetails : EntityBase
{
    [Column("order_id")]
    public string OrderId { get; set; } = null!;

    [Column("product_id")]
    public string ProductId { get; set; } = null!;

    [Column("product_name")]
    public string ProductName { get; set; } = null!;

    [Column("product_feature_image")]
    public string ProductFeatureImage { get; set; } = null!;

    [Column("product_quantity")]
    public int ProductQuantity { get; set; }

    [Column("total_price")]
    public double TotalPrice { get; set; }

    [Column("product_sale")]
    public int ProductSale { get; set; }

    [Column("total_sale_price")]
    public double TotalSalePrice { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("status")]
    public OrderStatus Status { get; set; }

    public Orders Order { get; set; } = new();
}
