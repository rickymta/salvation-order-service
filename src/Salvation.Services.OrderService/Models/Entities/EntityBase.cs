using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salvation.Services.OrderService.Models.Entities;

public class EntityBase
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;
}
