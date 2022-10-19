using CleanCode.PurchaseOrders.Domain.Exceptions;

namespace CleanCode.PurchaseOrders.Domain.ValueObjects
{
    public record InvoiceItem
    {
        public ulong InvoiceItemId { get; }
        public uint Quantity { get; }
        public string Description { get; }

        public InvoiceItem(ulong invoiceItemId, uint quantity, string description)
        {
            InvoiceItemId = invoiceItemId;
            Quantity = quantity;
            
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new EmptyInvoiceItemDescriptionException(this);
            }

            Description = description;
        }
    }
}
