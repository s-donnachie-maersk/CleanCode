using CleanCode.PurchaseOrders.Domain.Entities;
using CleanCode.PurchaseOrders.Domain.ValueObjects;

namespace CleanCode.PurchaseOrders.Domain.Repositories
{
    public interface IPurchaseOrderRepository
    {
        Task<PurchaseOrder?> GetAsync(PurchaseOrderId id);
        Task AddAsync(PurchaseOrder purchaseOrder);
        Task UpdateAsync(PurchaseOrder purchaseOrder);
        Task DeleteAsync(PurchaseOrder purchaseOrder);
    }
}
