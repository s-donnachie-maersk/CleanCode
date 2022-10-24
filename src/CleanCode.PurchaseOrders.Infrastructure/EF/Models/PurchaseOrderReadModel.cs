namespace CleanCode.PurchaseOrders.Infrastructure.EF.Models
{
    internal class PurchaseOrderReadModel
    {
        public Guid Id { get; set; }
        public int Version { get; set; }

        public string PurchaseOrderNumber { get; set; }

        public ICollection<InvoiceItemReadModel> Items { get; set; }
    }
}
