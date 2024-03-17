using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Infrastructures.Abstractions;
using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Context;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;

namespace Salvation.Services.OrderService.Infrastructures.Implementations;

public class TransportRepository : GenericRepository<Transports>, ITransportRepository
{
    public TransportRepository(ApplicationDbContext context, ILogProvider logger) : base(context, logger)
    {
    }

    public Task<DataPaging<Transports>?> FilterDataPagingAsync(TransportFilter filter)
    {
        throw new NotImplementedException();
    }
}
