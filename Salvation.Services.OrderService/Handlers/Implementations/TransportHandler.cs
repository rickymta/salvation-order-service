using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Handlers.Abstractions;
using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;
using Salvation.Services.OrderService.Services.Abstractions;

namespace Salvation.Services.OrderService.Handlers.Implementations;

public class TransportHandler : ITransportHandler
{
    private readonly ITransportService _transportService;

    private readonly ILogProvider _logProvider;

    public TransportHandler(ITransportService transportService, ILogProvider logProvider)
    {
        _transportService = transportService;
        _logProvider = logProvider;
    }

    public async Task<string> CreateAsync(TransportCreateRequest entity)
    {
        try
        {
            var res = await _transportService.CreateAsync(entity);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return string.Empty;
        }
    }

    public async Task<bool> DeleteAsync(TransportDeleteRequest request)
    {
        try
        {
            var res = await _transportService.DeleteAsync(request);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return false;
        }
    }

    public async Task<DataPaging<Transports>?> FilterDataPagingAsync(TransportFilter filter)
    {
        try
        {
            var res = await _transportService.FilterDataPagingAsync(filter);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<IEnumerable<Transports>?> GetAllAsync()
    {
        try
        {
            var res = await _transportService.GetAllAsync();
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<Transports?> GetAsync(string id)
    {
        try
        {
            var res = await _transportService.GetAsync(id);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<bool> UpdateAsync(TransportUpdateRequest entity)
    {
        try
        {
            var res = await _transportService.UpdateAsync(entity);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return false;
        }
    }
}
