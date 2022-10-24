using CleanCode.PurchaseOrders.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanCode.PurchaseOrders.Infrastructure.EF.Config;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<PurchaseOrderReadModel>, IEntityTypeConfiguration<InvoiceItemReadModel>
{
    public void Configure(EntityTypeBuilder<PurchaseOrderReadModel> builder)
    {
        builder.ToTable("PurchaseOrders");
        builder.HasKey(po => po.Id);

        builder
            .HasMany(po => po.Items)
            .WithOne(ii => ii.PurchaseOrder);
    }

    public void Configure(EntityTypeBuilder<InvoiceItemReadModel> builder)
    {
        builder.ToTable("InvoiceItems");
    }
}