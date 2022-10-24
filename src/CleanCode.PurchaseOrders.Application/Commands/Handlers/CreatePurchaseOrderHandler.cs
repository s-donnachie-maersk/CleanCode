using CleanCode.PurchaseOrders.Application.Exceptions;
using CleanCode.PurchaseOrders.Application.Services;
using CleanCode.PurchaseOrders.Domain.Factories;
using CleanCode.PurchaseOrders.Domain.Repositories;
using CleanCode.Shared.Abstractions.Commands;

namespace CleanCode.PurchaseOrders.Application.Commands.Handlers
{
    public class CreatePurchaseOrderHandler : ICommandHandler<CreatePurchaseOrder>
    {
        private readonly IPurchaseOrderRepository _repository;
        private readonly IPurchaseOrderFactory _factory;
        private readonly IPurchaseOrderReadService _readService;

        public CreatePurchaseOrderHandler(IPurchaseOrderRepository repository, IPurchaseOrderFactory factory, IPurchaseOrderReadService readService)
        {
            _repository = repository;
            _factory = factory;
            _readService = readService;
        }

        public async Task HandleAsync(CreatePurchaseOrder command)
        {
            if (await _readService.ExistsByPurchaseOrderNumberAsync(command.PurchaseOrderNumber))
            {
                throw new PurchaseOrderAlreadyExistsException(command.PurchaseOrderNumber);
            }

            var purchaseOrder = _factory.Create(command.PurchaseOrderNumber);

            await _repository.AddAsync(purchaseOrder);

            var events = purchaseOrder.Events;

            // Send out generated events
        }
    }
}
