using CleanCode.PurchaseOrders.Domain.Entities;
using CleanCode.PurchaseOrders.Domain.ValueObjects;

namespace CleanCode.PurchaseOrders.Domain.Factories
{
    public interface IPurchaseOrderFactory
    {
        PurchaseOrder Create(PurchaseOrderNumber purchaseOrderNumber);
    }
}
