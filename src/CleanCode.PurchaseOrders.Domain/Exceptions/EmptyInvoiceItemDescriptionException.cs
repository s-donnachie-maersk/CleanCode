using CleanCode.PurchaseOrders.Domain.ValueObjects;
using CleanCode.Shared.Abstractions.Exceptions;

namespace CleanCode.PurchaseOrders.Domain.Exceptions;

public class EmptyInvoiceItemDescriptionException : PurchaseOrderException
{
    public EmptyInvoiceItemDescriptionException(InvoiceItem invoiceItem) : base($"Order Item Description cannot be empty for supplied Invoice ID : {invoiceItem.InvoiceItemId}")
    {
    }
}