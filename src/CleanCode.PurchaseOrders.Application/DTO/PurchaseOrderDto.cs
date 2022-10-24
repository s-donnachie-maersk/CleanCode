namespace CleanCode.PurchaseOrders.Application.DTO
{
    public class PurchaseOrderDto
    {
        public Guid Id { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public IEnumerable<InvoiceItemDto> InvoiceItems { get; set; }
    }
}
