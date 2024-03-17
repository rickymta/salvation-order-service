using Salvation.Services.OrderService.Models.Enums;
using Salvation.Services.OrderService.Models.Request.Base;

namespace Salvation.Services.OrderService.Models.Request;

public class OrderDeleteRequest : DeleteRequestBase
{
    public string OrderCode { get; set; } = null!;

    public string AccountId { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public long TotalAmount { get; set; }

    public long TotalSale { get; set; }

    public string? TransportId { get; set; }

    public string? TransportCode { get; set; }

    public string? PaymentId { get; set; }

    public string? PaymentCode { get; set; }

    public string? VoucherId { get; set; }

    public double? VoucherSale { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

    public OrderStatus Status { get; set; } = OrderStatus.WaitingConfirm;
}
