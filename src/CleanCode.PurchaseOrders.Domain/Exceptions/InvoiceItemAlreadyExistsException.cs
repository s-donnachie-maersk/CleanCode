using CleanCode.PurchaseOrders.Domain.Entities;
using CleanCode.PurchaseOrders.Domain.ValueObjects;
using CleanCode.Shared.Abstractions.Exceptions;

namespace CleanCode.PurchaseOrders.Domain.Exceptions
{
    internal class InvoiceItemAlreadyExistsException : PurchaseOrderException
    {
        public Guid PurchaseOrderId { get; }
        public string Description { get; }

        public InvoiceItemAlreadyExistsException(PurchaseOrder po, InvoiceItem item) 
            : base($"PurchaseOrder Invoice Item list: '{po.Id}' already defined item '{item.Description}'")
        {
            PurchaseOrderId = po.Id;
            Description = item.Description;
        }
    }
}
