using CleanCode.PurchaseOrders.Domain.Entities;
using CleanCode.PurchaseOrders.Domain.ValueObjects;

namespace CleanCode.PurchaseOrders.Domain.Factories;

public sealed class PurchaseOrderFactory : IPurchaseOrderFactory
{
    public PurchaseOrder Create(PurchaseOrderId id, PurchaseOrderNumber purchaseOrderNumber) =>
        new(id, purchaseOrderNumber);
}