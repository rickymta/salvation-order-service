using Microsoft.EntityFrameworkCore;
using Salvation.Services.OrderService.Models.Entities;

namespace Salvation.Services.OrderService.Models.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Orders> Orders { get; set; }

    public DbSet<OrderDetails> OrderDetails { get; set; }

    public DbSet<PaymentMethods> PaymentMethods { get; set; }

    public DbSet<Transports> Transports { get; set; }

    public DbSet<Vouchers> Vouchers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingInternal(modelBuilder);
    }

    internal static void OnModelCreatingInternal(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Orders>(entity =>
        {
            entity.HasMany(_ => _.OrderDetails)
                .WithOne(_ => _.Order)
                .HasForeignKey(_ => _.OrderId);
        });

        modelBuilder.Entity<PaymentMethods>(entity =>
        {
            entity.HasMany(_ => _.Orders)
                .WithOne(_ => _.PaymentMethod)
                .HasForeignKey(_ => _.PaymentId);
        });

        modelBuilder.Entity<Transports>(entity =>
        {
            entity.HasMany(_ => _.Orders)
                .WithOne(_ => _.Transport)
                .HasForeignKey(_ => _.TransportId);
        });

        modelBuilder.Entity<Vouchers>(entity =>
        {
            entity.HasMany(_ => _.Orders)
                .WithOne(_ => _.Voucher)
                .HasForeignKey(_ => _.VoucherId);
        });
    }
}
