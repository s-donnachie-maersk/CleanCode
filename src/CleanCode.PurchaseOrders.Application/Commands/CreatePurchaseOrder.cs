using CleanCode.Shared.Abstractions.Commands;

namespace CleanCode.PurchaseOrders.Application.Commands
{
    public record CreatePurchaseOrder(string PurchaseOrderNumber) : ICommand;
}
