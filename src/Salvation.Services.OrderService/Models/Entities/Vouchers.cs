using System.ComponentModel.DataAnnotations.Schema;

namespace Salvation.Services.OrderService.Models.Entities;

[Table("vouchers")]
public class Vouchers : EntityBase
{
    [Column("voucher_code")]
    public string VoucherCode { get; set; } = null!;

    [Column("sale")]
    public int Sale { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("admin_id")]
    public string? AdminId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("status")]
    public int Status { get; set; }

    public ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
