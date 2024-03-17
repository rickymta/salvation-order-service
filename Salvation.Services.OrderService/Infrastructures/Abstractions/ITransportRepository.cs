using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;

namespace Salvation.Services.OrderService.Infrastructures.Abstractions;

public interface ITransportRepository : IGenericRepository<Transports>
{
    Task<DataPaging<Transports>?> FilterDataPagingAsync(TransportFilter filter);
}
