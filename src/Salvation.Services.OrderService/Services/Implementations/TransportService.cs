using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Infrastructures.Abstractions;
using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;
using Salvation.Services.OrderService.Models.Request;
using Salvation.Services.OrderService.Services.Abstractions;

namespace Salvation.Services.OrderService.Services.Implementations;

public class TransportService : ITransportService
{
    private readonly ITransportRepository _transportRepository;

    private readonly ILogProvider _logProvider;

    public TransportService(ITransportRepository transportRepository, ILogProvider logProvider)
    {
        _transportRepository = transportRepository;
        _logProvider = logProvider;
    }

    public async Task<string> CreateAsync(TransportCreateRequest request)
    {
        try
        {
            var entity = new Transports
            {
                Id = request.Id,
                AdminId = request.AdminId,
                Code = request.Code,
                Description = request.Description,
                Name = request.Name,
                Price = request.Price,
                Status = request.Status,
                CreatedAt = request.CreatedAt
            };

            var res = await _transportRepository.CreateAsync(entity);
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
            var res = await _transportRepository.DeleteAsync(request.Id);
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
            var res = await _transportRepository.FilterDataPagingAsync(filter);
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
            var res = await _transportRepository.GetAllAsync();
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
            var res = await _transportRepository.GetAsync(id);
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<bool> UpdateAsync(TransportUpdateRequest request)
    {
        try
        {
            var entity = await GetAsync(request.Id);

            if (entity != null)
            {
                entity.AdminId = request.AdminId;
                entity.Code = request.Code;
                entity.Description = request.Description;
                entity.Name = request.Name;
                entity.Price = request.Price.Value;
                entity.Status = request.Status.Value;
                entity.UpdatedAt = request.UpdatedAt;
                var res = await _transportRepository.UpdateAsync(entity);
                return res;
            }
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
        }

        return false;
    }
}
