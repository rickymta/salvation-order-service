using Microsoft.AspNetCore.Mvc;
using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Controllers.Base;
using Salvation.Services.OrderService.Handlers.Abstractions;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;

namespace Salvation.Services.OrderService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VoucherController : BaseController
{
    private readonly IVoucherHandler _voucherHandler;

    private readonly ILogProvider _logProvider;

    public VoucherController(IVoucherHandler voucherHandler, ILogProvider logProvider)
    {
        _voucherHandler = voucherHandler;
        _logProvider = logProvider;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(VoucherCreateRequest entity)
    {
        try
        {
            var res = await _voucherHandler.CreateAsync(entity);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(VoucherDeleteRequest request)
    {
        try
        {
            var res = await _voucherHandler.DeleteAsync(request);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("filter")]
    public async Task<IActionResult> FilterDataPagingAsync(VoucherFilter filter)
    {
        try
        {
            var res = await _voucherHandler.FilterDataPagingAsync(filter);
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
            var res = await _voucherHandler.GetAllAsync();
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
            var res = await _voucherHandler.GetAsync(id);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(VoucherUpdateRequest entity)
    {
        try
        {
            var res = await _voucherHandler.UpdateAsync(entity);
            return Ok(SuccessData(res));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return BadRequest(ex.Message);
        }
    }
}
