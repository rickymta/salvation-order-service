using System.ComponentModel.DataAnnotations.Schema;

namespace Salvation.Services.OrderService.Models.Entities;

[Table("transports")]
public class Transports : EntityBase
{
    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string Description { get; set; } = null!;

    [Column("code")]
    public string Code { get; set; } = null!;

    [Column("price")]
    public double Price { get; set; }

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
