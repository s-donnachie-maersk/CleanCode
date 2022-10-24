using CleanCode.PurchaseOrders.Application.DTO;
using CleanCode.Shared.Abstractions.Queries;

namespace CleanCode.PurchaseOrders.Application.Queries
{
    public class GetPurchaseOrder : IQuery<PurchaseOrderDto>
    {
        public string PurchaseOrderNumber { get; set; }
    }
}
