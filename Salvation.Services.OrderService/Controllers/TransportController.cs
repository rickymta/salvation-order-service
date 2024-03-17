using Microsoft.AspNetCore.Mvc;
using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Controllers.Base;
using Salvation.Services.OrderService.Handlers.Abstractions;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;

namespace Salvation.Services.OrderService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransportController : BaseController
{
    private readonly ITransportHandler _transportHandler;

    private readonly ILogProvider _logProvider;

    public TransportController(ITransportHandler transportHandler, ILogProvider logProvider)
    {
        _transportHandler = transportHandler;
        _logProvider = logProvider;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(TransportCreateRequest entity)
    {
        try
        {
            var res = await _transportHandler.CreateAsync(entity);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(TransportDeleteRequest request)
    {
        try
        {
            var res = await _transportHandler.DeleteAsync(request);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("filter")]
    public async Task<IActionResult> FilterDataPagingAsync(TransportFilter filter)
    {
        try
        {
            var res = await _transportHandler.FilterDataPagingAsync(filter);
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
            var res = await _transportHandler.GetAllAsync();
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
            var res = await _transportHandler.GetAsync(id);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(TransportUpdateRequest entity)
    {
        try
        {
            var res = await _transportHandler.UpdateAsync(entity);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }
}
