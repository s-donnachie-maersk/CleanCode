using CleanCode.PurchaseOrders.Application.Exceptions;
using CleanCode.PurchaseOrders.Application.Services;
using CleanCode.PurchaseOrders.Domain.Repositories;
using CleanCode.PurchaseOrders.Domain.ValueObjects;
using CleanCode.Shared.Abstractions.Commands;

namespace CleanCode.PurchaseOrders.Application.Commands.Handlers;

public class AddInvoiceItemHandler : ICommandHandler<AddInvoiceItem>
{
    private readonly IPurchaseOrderRepository _repository;
    private readonly IPurchaseOrderReadService _readService;

    public AddInvoiceItemHandler(IPurchaseOrderRepository repository, IPurchaseOrderReadService readService)
    {
        _repository = repository;
        _readService = readService;
    }

    public async Task HandleAsync(AddInvoiceItem command)
    {
        var (purchaseOrderNumber, description, quantity) = command;

        if (!await _readService.ExistsByPurchaseOrderNumberAsync(purchaseOrderNumber))
        {
            throw new PurchaseOrderNotFoundException(purchaseOrderNumber);
        }

        var purchaseOrder = await _repository.GetAsync(command.PurchaseOrderNumber);

        purchaseOrder!.AddItem(new InvoiceItem(quantity, description));

        await _repository.UpdateAsync(purchaseOrder);

        var events = purchaseOrder.Events;

        // Send out generated events
    }
}