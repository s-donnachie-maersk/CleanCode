using CleanCode.Shared.Abstractions.Exceptions;

namespace CleanCode.PurchaseOrders.Application.Exceptions
{
    public class PurchaseOrderAlreadyExistsException : PurchaseOrderException
    {
        public string PurchaseOrderNumber { get; }

        public PurchaseOrderAlreadyExistsException(string purchaseOrderNumber) : base($"Purchase order with number '{purchaseOrderNumber}' already exists")
        {
            PurchaseOrderNumber = purchaseOrderNumber;
        }
    }
}
