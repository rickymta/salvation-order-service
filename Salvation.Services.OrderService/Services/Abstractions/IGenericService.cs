using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters.Base;
using Salvation.Services.OrderService.Models.Request.Base;

namespace Salvation.Services.OrderService.Services.Abstractions;

public interface IGenericService<TEntity, TFilter, TCreate, TUpdate, TDelete>
    where TEntity : EntityBase
    where TFilter : FilterBase
    where TCreate : CreateRequestBase
    where TUpdate : UpdateRequestBase
    where TDelete : DeleteRequestBase
{
    Task<string> CreateAsync(TCreate entity);

    Task<TEntity?> GetAsync(string id);

    Task<IEnumerable<TEntity>?> GetAllAsync();

    Task<DataPaging<TEntity>?> FilterDataPagingAsync(TFilter filter);

    Task<bool> DeleteAsync(TDelete request);

    Task<bool> UpdateAsync(TUpdate entity);
}
