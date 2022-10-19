using CleanCode.PurchaseOrders.Domain.Events;
using CleanCode.PurchaseOrders.Domain.Exceptions;
using CleanCode.PurchaseOrders.Domain.ValueObjects;
using CleanCode.Shared.Abstractions.Domain;

namespace CleanCode.PurchaseOrders.Domain.Entities
{
    public class PurchaseOrder : AggregateRoot<Guid>
    {
        public PurchaseOrderId Id { get; private set; }
        public PurchaseOrderNumber PurchaseOrderNumber { get; private set; }

        private readonly LinkedList<InvoiceItem> _items = new();

        internal PurchaseOrder(PurchaseOrderId id, PurchaseOrderNumber purchaseOrderNumber)
        {
            Id = id;
            PurchaseOrderNumber = purchaseOrderNumber;
        }

        private PurchaseOrder()
        {

        }

        public void AddItem(InvoiceItem item)
        {
            var alreadyExists = _items.Any(x => x.InvoiceItemId == item.InvoiceItemId);

            if (alreadyExists)
            {
                throw new InvoiceItemAlreadyExistsException(this, item);
            }

            _items.AddLast(item);
            AddEvent(new InvoiceItemAdded(item));
        }

        public void AddItems(IEnumerable<InvoiceItem> items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }
    }
}
