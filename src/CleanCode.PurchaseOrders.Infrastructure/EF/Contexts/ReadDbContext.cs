using CleanCode.PurchaseOrders.Infrastructure.EF.Config;
using CleanCode.PurchaseOrders.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.PurchaseOrders.Infrastructure.EF.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<PurchaseOrderReadModel> PurchaseOrders { get; set; }

    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("purchaseOrder");

        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<PurchaseOrderReadModel>(configuration);
        modelBuilder.ApplyConfiguration<InvoiceItemReadModel>(configuration);
    }
}