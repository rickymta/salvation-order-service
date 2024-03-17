using Microsoft.AspNetCore.Mvc;
using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Controllers.Base;
using Salvation.Services.OrderService.Handlers.Abstractions;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;

namespace Salvation.Services.OrderService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailController : BaseController
{
    private readonly IOrderDetailHandler _orderDetailHandler;

    private readonly ILogProvider _logProvider;

    public OrderDetailController(IOrderDetailHandler orderDetailHandler, ILogProvider logProvider)
    {
        _orderDetailHandler = orderDetailHandler;
        _logProvider = logProvider;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(OrderDetailCreateRequest entity)
    {
        try
        {
            var res = await _orderDetailHandler.CreateAsync(entity);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(OrderDetailDeleteRequest request)
    {
        try
        {
            var res = await _orderDetailHandler.DeleteAsync(request);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("filter")]
    public async Task<IActionResult> FilterDataPagingAsync(OrderDetailFilter filter)
    {
        try
        {
            var res = await _orderDetailHandler.FilterDataPagingAsync(filter);
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
            var res = await _orderDetailHandler.GetAllAsync();
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
            var res = await _orderDetailHandler.GetAsync(id);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(OrderDetailUpdateRequest entity)
    {
        try
        {
            var res = await _orderDetailHandler.UpdateAsync(entity);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }
}
