using Dapper;
using Microsoft.EntityFrameworkCore;
using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Infrastructures.Abstractions;
using Salvation.Services.OrderService.Models.Context;
using Salvation.Services.OrderService.Models.Entities;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Salvation.Services.OrderService.Infrastructures.Implementations;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
{
    protected readonly ApplicationDbContext _context;

    protected readonly ILogProvider _logProvider;

    protected readonly IConfiguration _configuration;

    public GenericRepository(ApplicationDbContext context, ILogProvider logger, IConfiguration configuration)
    {
        _context = context;
        _logProvider = logger;
        _configuration = configuration;
    }

    public async Task<string> CreateAsync(TEntity entity)
    {
        try
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return string.Empty;
        }
    }

    public async Task<bool> DeleteAsync(string id)
    {
        try
        {
            TEntity entity = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return false;
        }
    }

    public async Task<IEnumerable<TEntity>?> GetAllAsync()
    {
        try
        {
            var res = await _context.Set<TEntity>().ToListAsync();
            return res;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
        }

        return null;
    }

    public async Task<TEntity?> GetAsync(string id)
    {
        try
        {
            TEntity entity = await _context.Set<TEntity>().FindAsync(id);
            return entity;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
        }

        return null;
    }

    public Task<bool> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TEntity>?> GetBySql(string sql, object filter, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            var result = await connection.QueryAsync<TEntity>(sql, filter, transaction: transaction);
            return result;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    public async Task<long> CountBySql(string sql, object filter, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            var count = await connection.QueryAsync<int>(sql, filter, transaction: transaction);

            if (!count.Any())
            {
                return 0;
            }

            return (long)count.First();
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return 0;
        }
    }
}
