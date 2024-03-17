namespace Salvation.Services.OrderService.Models.Enums;

public enum OrderStatus
{
    Error = -2,
    Cancel = -1,
    WaitingConfirm = 0,
    Confirmed = 1,
    Shipping = 2,
    Delivered = 3
}
