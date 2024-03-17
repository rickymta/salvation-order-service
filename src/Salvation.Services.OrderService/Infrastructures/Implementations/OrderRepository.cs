using Npgsql;
using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Infrastructures.Abstractions;
using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Context;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;

namespace Salvation.Services.OrderService.Infrastructures.Implementations;

public class OrderRepository : GenericRepository<Orders>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context, ILogProvider logger, IConfiguration configuration) : base(context, logger, configuration)
    {
    }

    public async Task<DataPaging<Orders>?> FilterDataPagingAsync(OrderFilter filter)
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

                if (!string.IsNullOrEmpty(filter.OrderCode))
                {
                    condition.Add("order_code = '%@OrderCode%'");
                }

                if (!string.IsNullOrEmpty(filter.AccountId))
                {
                    condition.Add("account_id = '%@AccountId%'");
                }

                if (!string.IsNullOrEmpty(filter.FullName))
                {
                    condition.Add("full_name like '%@FullName%'");
                }

                if (!string.IsNullOrEmpty(filter.PhoneNumber))
                {
                    condition.Add("phone_number = '%@PhoneNumber%'");
                }

                if (!string.IsNullOrEmpty(filter.Address))
                {
                    condition.Add("address = '%@Address%'");
                }

                if (filter.TotalAmount != null)
                {
                    condition.Add("total_amount = @TotalAmount");
                }

                if (filter.TotalSale != null)
                {
                    condition.Add("total_sale = @TotalSale");
                }

                if (!string.IsNullOrEmpty(filter.TransportId))
                {
                    condition.Add("transport_id = '%@TransportId%'");
                }

                if (!string.IsNullOrEmpty(filter.PaymentId))
                {
                    condition.Add("payment_id = '%@PaymentId%'");
                }

                if (!string.IsNullOrEmpty(filter.VoucherId))
                {
                    condition.Add("voucher_id = '%@VoucherId%'");
                }

                if (filter.VoucherSale != null)
                {
                    condition.Add("voucher_sale = @VoucherSale");
                }

                if (filter.Status != null)
                {
                    condition.Add("status = @Status");
                }

                if (filter.CreatedStartDate != null)
                {
                    condition.Add("create_at >= @CreatedStartDate");
                }

                if (filter.CreatedEndDate != null)
                {
                    condition.Add("create_at ><= @CreatedEndDate");
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
