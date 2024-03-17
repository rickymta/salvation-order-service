﻿using Salvation.Services.OrderService.Models.Enums;
using Salvation.Services.OrderService.Models.Request.Base;

namespace Salvation.Services.OrderService.Models.Request;

public class OrderUpdateRequest : UpdateRequestBase
{
    public string? OrderCode { get; set; }

    public string? AccountId { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public long? TotalAmount { get; set; }

    public long? TotalSale { get; set; }

    public string? TransportId { get; set; }

    public string? TransportCode { get; set; }

    public string? PaymentId { get; set; }

    public string? PaymentCode { get; set; }

    public string? VoucherId { get; set; }

    public double? VoucherSale { get; set; }

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public OrderStatus? Status { get; set; }
}
