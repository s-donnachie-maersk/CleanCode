using CleanCode.Shared.Abstractions.Commands;

namespace CleanCode.PurchaseOrders.Application.Commands
{
    public record AddInvoiceItem(string PurchaseOrderNumber, string description, uint quantity) : ICommand;
}
