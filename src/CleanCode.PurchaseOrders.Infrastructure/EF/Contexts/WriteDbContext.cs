using CleanCode.PurchaseOrders.Domain.Entities;
using CleanCode.PurchaseOrders.Domain.ValueObjects;
using CleanCode.PurchaseOrders.Infrastructure.EF.Config;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.PurchaseOrders.Infrastructure.EF.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("purchaseOrder");
            
            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<PurchaseOrder>(configuration);
            modelBuilder.ApplyConfiguration<InvoiceItem>(configuration);
        }
    }
}
