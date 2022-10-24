using CleanCode.PurchaseOrders.Domain.Exceptions;

namespace CleanCode.PurchaseOrders.Domain.ValueObjects
{
    public record InvoiceItem
    {
        public uint Quantity { get; }
        public string Description { get; }

        public InvoiceItem(uint quantity, string description)
        {
            Quantity = quantity;
            
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new EmptyInvoiceItemDescriptionException(this);
            }

            Description = description;
        }
    }
}
