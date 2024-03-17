using Npgsql;
using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Infrastructures.Abstractions;
using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Context;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;

namespace Salvation.Services.OrderService.Infrastructures.Implementations;

public class VoucherRepository : GenericRepository<Vouchers>, IVoucherRepository
{
    public VoucherRepository(ApplicationDbContext context, ILogProvider logger, IConfiguration configuration) : base(context, logger, configuration)
    {
    }

    public async Task<DataPaging<Vouchers>?> FilterDataPagingAsync(VoucherFilter filter)
    {
        try
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                filter.Page ??= 0;
                filter.Limit ??= 50;
                int offset = filter.Page.Value * filter.Limit.Value;
                filter.Offset = offset;
                var condition = new List<string>();

                if (!string.IsNullOrEmpty(filter.VoucherCode))
                {
                    condition.Add("voucher_code = '%@VoucherCode%'");
                }

                if (!string.IsNullOrEmpty(filter.AdminId))
                {
                    condition.Add("admin_id = '%@AdminId%'");
                }

                if (filter.Sale != null)
                {
                    condition.Add("sale = @Sale");
                }

                if (filter.Quantity != null)
                {
                    condition.Add("quantity = @Quantity");
                }

                if (filter.Status != null)
                {
                    condition.Add("status = @Status");
                }

                var sqlCount = "SELECT COUNT(id) FROM order_details WHERE Id <> '' ";
                var sql = "SELECT * FROM order_details WHERE id <> '' ";

                if (condition.Any())
                {
                    sqlCount += " AND " + $"{string.Join("AND", condition)}";
                    sql += " AND " + $"{string.Join("AND", condition)}";
                }

                sql += " ORDER BY created_at DESC LIMIT @Limit OFFSET @Offset";
                var count = await CountBySql(sqlCount, filter, connection, connection.BeginTransaction());
                var data = await GetBySql(sql, filter, connection, connection.BeginTransaction());
            }
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
        }

        return null;
    }
}
