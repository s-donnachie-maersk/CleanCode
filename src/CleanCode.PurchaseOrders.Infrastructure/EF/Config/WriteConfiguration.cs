using CleanCode.PurchaseOrders.Domain.Entities;
using CleanCode.PurchaseOrders.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanCode.PurchaseOrders.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<PurchaseOrder>, IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.HasKey(pl => pl.Id);

            var purchaseOrderNumber = new ValueConverter<PurchaseOrderNumber, string>(pln => pln.Value,
                pln => new PurchaseOrderNumber(pln));

            builder
                .Property(pl => pl.Id)
                .HasConversion(id => id.Value, id => new PurchaseOrderId(id));

            builder
                .Property(pl => pl.PurchaseOrderNumber)
                .HasConversion(purchaseOrderNumber);

            builder.HasMany(typeof(InvoiceItem), "_items");

            builder.ToTable("PurchaseOrders");
        }

        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.Property<Guid>("Id");
            builder.Property(pi => pi.Quantity);
            builder.Property(pi => pi.Description);
            builder.ToTable("InvoiceItems");
        }
    }
}
