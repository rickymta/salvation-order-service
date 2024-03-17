using Salvation.Services.OrderService.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salvation.Services.OrderService.Models.Entities;

[Table("orders")]
public class Orders : EntityBase
{
    [Column("order_code")]
    public string OrderCode { get; set; } = null!;

    [Column("account_id")]
    public string AccountId { get; set; } = null!;

    [Column("full_name")]
    public string FullName { get; set; } = null!;

    [Column("phone_number")]
    public string PhoneNumber { get; set; } = null!;

    [Column("address")]
    public string Address { get; set; } = null!;

    [Column("total_amount")]
    public long TotalAmount { get; set; }

    [Column("total_sale")]
    public long TotalSale { get; set; }

    [Column("trnasport_id")]
    public string TransportId { get; set; } = null!;

    [Column("transport_code")]
    public string TransportCode { get; set; } = null!;

    [Column("payment_id")]
    public string PaymentId { get; set; } = null!;

    [Column("payment_code")]
    public string PaymentCode { get; set; } = null!;

    [Column("voucher_id")]
    public string? VoucherId { get; set; }

    [Column("voucher_code")]
    public double? VoucherSale { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("status")]
    public OrderStatus Status { get; set; }

    public Transports Transport { get; set; } = new();

    public PaymentMethods PaymentMethod { get; set; } = new();

    public Vouchers Voucher { get; set; } = new();

    public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
}
