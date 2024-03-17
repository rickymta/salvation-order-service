using Salvation.Services.OrderService.Models.Entities;

namespace Salvation.Services.OrderService.Infrastructures.Abstractions;

public interface IGenericRepository<TEntity> where TEntity : EntityBase
{
    Task<string> CreateAsync(TEntity entity);

    Task<TEntity?> GetAsync(string id);

    Task<IEnumerable<TEntity>?> GetAllAsync();

    Task<bool> DeleteAsync(string id);

    Task<bool> UpdateAsync(TEntity entity);
}
