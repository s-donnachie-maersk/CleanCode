using CleanCode.PurchaseOrders.Application.Services;
using CleanCode.PurchaseOrders.Infrastructure.EF.Contexts;
using CleanCode.PurchaseOrders.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.PurchaseOrders.Infrastructure.EF.Services
{
    internal sealed class PostgresPurchaseOrderReadService : IPurchaseOrderReadService
    {
        private readonly DbSet<PurchaseOrderReadModel> _purchaseOrders;

        public PostgresPurchaseOrderReadService(ReadDbContext context) => _purchaseOrders = context.PurchaseOrders;

        public Task<bool> ExistsByPurchaseOrderNumberAsync(string purchaseOrderNumber) =>
            _purchaseOrders.AnyAsync(po => po.PurchaseOrderNumber == purchaseOrderNumber);
    }
}
