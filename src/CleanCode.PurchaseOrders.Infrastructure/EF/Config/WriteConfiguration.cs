using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCode.PurchaseOrders.Domain.Entities;
using CleanCode.PurchaseOrders.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanCode.PurchaseOrders.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<PurchaseOrder>, IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.HasKey(pl => pl.Id);

            builder
                .Property(pl => pl.Id)
                .HasConversion(id => id.Value, id => new PurchaseOrderId(id));

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
