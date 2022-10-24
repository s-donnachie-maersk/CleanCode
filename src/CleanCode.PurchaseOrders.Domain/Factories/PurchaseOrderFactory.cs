using CleanCode.PurchaseOrders.Domain.Entities;
using CleanCode.PurchaseOrders.Domain.ValueObjects;

namespace CleanCode.PurchaseOrders.Domain.Factories;

public sealed class PurchaseOrderFactory : IPurchaseOrderFactory
{
    public PurchaseOrder Create(PurchaseOrderNumber purchaseOrderNumber) =>
        new(purchaseOrderNumber);
}