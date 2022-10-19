using CleanCode.Shared.Abstractions.Exceptions;

namespace CleanCode.PurchaseOrders.Domain.Exceptions;

public class EmptyPurchaseOrderIdException : PurchaseOrderException
{
    public EmptyPurchaseOrderIdException() : base("Purchase Order ID cannot be empty.")
    {
    }
}