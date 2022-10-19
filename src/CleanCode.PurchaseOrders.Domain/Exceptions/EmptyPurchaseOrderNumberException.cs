using CleanCode.Shared.Abstractions.Exceptions;

namespace CleanCode.PurchaseOrders.Domain.Exceptions;

public class EmptyPurchaseOrderNumberException : PurchaseOrderException
{
    public EmptyPurchaseOrderNumberException() : base("Purchase Order Number cannot be empty.")
    {
    }
}