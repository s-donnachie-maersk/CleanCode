using CleanCode.Shared.Abstractions.Queries;
using CleanCode.PurchaseOrders.Application.DTO;
using CleanCode.PurchaseOrders.Application.Queries;
using CleanCode.PurchaseOrders.Infrastructure.EF.Contexts;
using CleanCode.PurchaseOrders.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.PurchaseOrders.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetPurchaseOrderHandler : IQueryHandler<GetPurchaseOrder, PurchaseOrderDto>
    {
        private readonly DbSet<PurchaseOrderReadModel> _purchaseOrders;

        public GetPurchaseOrderHandler(ReadDbContext context)
            => _purchaseOrders = context.PurchaseOrders;

        public Task<PurchaseOrderDto> HandleAsync(GetPurchaseOrder query)
            => _purchaseOrders
                .Include(pl => pl.Items)
                .Where(pl => pl.PurchaseOrderNumber == query.PurchaseOrderNumber)
                .Select(pl => pl.AsDto())
                .AsNoTracking()
                .SingleOrDefaultAsync()!;
    }
}
