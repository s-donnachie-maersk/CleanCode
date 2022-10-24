namespace CleanCode.PurchaseOrders.Infrastructure.EF.Models;

internal class InvoiceItemReadModel
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public uint Quantity { get; set; }

    public PurchaseOrderReadModel PurchaseOrder { get; set; }
}