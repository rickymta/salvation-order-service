using Microsoft.AspNetCore.Mvc;
using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Controllers.Base;
using Salvation.Services.OrderService.Handlers.Abstractions;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;

namespace Salvation.Services.OrderService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : BaseController
{
    private readonly IOrderHandler _orderHandler;

    private readonly ILogProvider _logProvider;

    public OrderController(IOrderHandler orderHandler, ILogProvider logProvider)
    {
        _orderHandler = orderHandler;
        _logProvider = logProvider;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(OrderCreateRequest entity)
    {
        try
        {
            var res = await _orderHandler.CreateAsync(entity);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(OrderDeleteRequest request)
    {
        try
        {
            var res = await _orderHandler.DeleteAsync(request);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("filter")]
    public async Task<IActionResult> FilterDataPagingAsync(OrderFilter filter)
    {
        try
        {
            var res = await _orderHandler.FilterDataPagingAsync(filter);
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
            var res = await _orderHandler.GetAllAsync();
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
            var res = await _orderHandler.GetAsync(id);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(OrderUpdateRequest entity)
    {
        try
        {
            var res = await _orderHandler.UpdateAsync(entity);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }
}
