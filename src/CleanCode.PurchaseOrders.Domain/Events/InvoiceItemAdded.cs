using CleanCode.PurchaseOrders.Domain.ValueObjects;
using CleanCode.Shared.Abstractions.Domain;

namespace CleanCode.PurchaseOrders.Domain.Events
{
    public record InvoiceItemAdded(InvoiceItem InvoiceItem) : IDomainEvent;
}
