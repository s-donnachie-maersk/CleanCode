using CleanCode.PurchaseOrders.Domain.Factories;
using CleanCode.PurchaseOrders.Domain.Repositories;
using CleanCode.Shared.Abstractions.Commands;

namespace CleanCode.PurchaseOrders.Application.Commands.Handlers
{
    public class CreatePurchaseOrderHandler : ICommandHandler<CreatePurchaseOrder>
    {
        private readonly IPurchaseOrderRepository _repository;
        private readonly IPurchaseOrderFactory _factory;

        public CreatePurchaseOrderHandler(IPurchaseOrderRepository repository, IPurchaseOrderFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task HandleAsync(CreatePurchaseOrder command)
        {
            var (id, purchaseOrderNumber) = command;

            var purchaseOrder = _factory.Create(id, purchaseOrderNumber);

            await _repository.AddAsync(purchaseOrder);
        }
    }
}
