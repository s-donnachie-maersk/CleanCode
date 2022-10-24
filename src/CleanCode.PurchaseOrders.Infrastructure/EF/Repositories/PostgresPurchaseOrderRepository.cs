using CleanCode.PurchaseOrders.Domain.Entities;
using CleanCode.PurchaseOrders.Domain.Repositories;
using CleanCode.PurchaseOrders.Domain.ValueObjects;
using CleanCode.PurchaseOrders.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.PurchaseOrders.Infrastructure.EF.Repositories
{
    internal sealed class PostgresPurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly WriteDbContext _writeDbContext;
        private readonly DbSet<PurchaseOrder> _purchaseOrders;

        public PostgresPurchaseOrderRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _purchaseOrders = _writeDbContext.PurchaseOrders;
        }

        public Task<PurchaseOrder?> GetAsync(PurchaseOrderNumber purchaseOrderNumber) =>
            _purchaseOrders.Include("_items").SingleOrDefaultAsync(po => po.PurchaseOrderNumber == purchaseOrderNumber);

        public async Task AddAsync(PurchaseOrder purchaseOrder)
        {
            await _purchaseOrders.AddAsync(purchaseOrder);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PurchaseOrder purchaseOrder)
        {
            _purchaseOrders.Update(purchaseOrder);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(PurchaseOrder purchaseOrder)
        {
            _purchaseOrders.Remove(purchaseOrder);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
