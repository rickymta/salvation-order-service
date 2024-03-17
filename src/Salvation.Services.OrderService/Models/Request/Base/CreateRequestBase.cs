namespace Salvation.Services.OrderService.Models.Request.Base;

public class CreateRequestBase
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
}
