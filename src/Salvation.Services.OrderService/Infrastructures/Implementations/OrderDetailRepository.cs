using Npgsql;
using Salvation.Services.OrderService.Common.Abstractions;
using Salvation.Services.OrderService.Infrastructures.Abstractions;
using Salvation.Services.OrderService.Models.Common;
using Salvation.Services.OrderService.Models.Context;
using Salvation.Services.OrderService.Models.Entities;
using Salvation.Services.OrderService.Models.Filters;

namespace Salvation.Services.OrderService.Infrastructures.Implementations;

public class OrderDetailRepository : GenericRepository<OrderDetails>, IOrderDetailRepository
{
    public OrderDetailRepository(ApplicationDbContext context, ILogProvider logger, IConfiguration configuration) : base(context, logger, configuration)
    {
    }

    public async Task<DataPaging<OrderDetails>?> FilterDataPagingAsync(OrderDetailFilter filter)
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

                if (!string.IsNullOrEmpty(filter.OrderId))
                {
                    condition.Add("order_id like '%@OrderId%'");
                }

                if (!string.IsNullOrEmpty(filter.ProductId))
                {
                    condition.Add("product_id like '%@ProductId%'");
                }

                if (!string.IsNullOrEmpty(filter.ProductName))
                {
                    condition.Add("product_name like '%@ProductName%'");
                }

                if (!string.IsNullOrEmpty(filter.ProductFeatureImage))
                {
                    condition.Add("product_feature_image like '%@ProductFeatureImage%'");
                }

                if (filter.ProductQuantity != null)
                {
                    condition.Add("product_quantity = @ProductQuantity");
                }

                if (filter.TotalPrice != null)
                {
                    condition.Add("total_price = @TotalPrice");
                }

                if (filter.ProductSale != null)
                {
                    condition.Add("product_sale = @ProductSale");
                }

                if (filter.TotalSalePrice != null)
                {
                    condition.Add("total_sale_price = @TotalSalePrice");
                }

                if (filter.Status != null)
                {
                    condition.Add("status = @Status");
                }

                if (filter.CreateStartDate != null)
                {
                    condition.Add("create_at >= @CreateStartDate");
                }

                if (filter.CreateEndDate != null)
                {
                    condition.Add("create_at ><= @CreateEndDate");
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
