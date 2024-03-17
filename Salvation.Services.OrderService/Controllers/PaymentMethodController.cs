using Microsoft.AspNetCore.Mvc;
using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Controllers.Base;
using Salvation.Services.OrderService.Handlers.Abstractions;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;

namespace Salvation.Services.OrderService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentMethodController : BaseController
{
    private readonly IPaymentMethodHandler _paymentMethodHandler;

    private readonly ILogProvider _logProvider;

    public PaymentMethodController(IPaymentMethodHandler paymentMethodHandler, ILogProvider logProvider)
    {
        _paymentMethodHandler = paymentMethodHandler;
        _logProvider = logProvider;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(PaymentMethodCreateRequest entity)
    {
        try
        {
            var res = await _paymentMethodHandler.CreateAsync(entity);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(PaymentMethodDeleteRequest request)
    {
        try
        {
            var res = await _paymentMethodHandler.DeleteAsync(request);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("filter")]
    public async Task<IActionResult> FilterDataPagingAsync(PaymentMethodFilter filter)
    {
        try
        {
            var res = await _paymentMethodHandler.FilterDataPagingAsync(filter);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var res = await _paymentMethodHandler.GetAllAsync();
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetAsync(string id)
    {
        try
        {
            var res = await _paymentMethodHandler.GetAsync(id);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(PaymentMethodUpdateRequest entity)
    {
        try
        {
            var res = await _paymentMethodHandler.UpdateAsync(entity);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }
}
