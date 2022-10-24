using CleanCode.Shared.Abstractions.Exceptions;

namespace CleanCode.PurchaseOrders.Application.Exceptions;

public class PurchaseOrderNotFoundException : PurchaseOrderException
{
    public string PurchaseOrderNumber { get; }

    public PurchaseOrderNotFoundException(string purchaseOrderNumber) : base($"Purchase order with number '{purchaseOrderNumber}' was not found")
    {
        PurchaseOrderNumber = purchaseOrderNumber;
    }
}