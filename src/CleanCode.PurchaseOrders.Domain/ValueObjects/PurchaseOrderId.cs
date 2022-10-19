using CleanCode.PurchaseOrders.Domain.Exceptions;

namespace CleanCode.PurchaseOrders.Domain.ValueObjects;

public record PurchaseOrderId
{
    public Guid Value { get; }

    public PurchaseOrderId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyPurchaseOrderIdException();
        }
            
        Value = value;
    }
        
    public static implicit operator Guid(PurchaseOrderId id)
        => id.Value;
        
    public static implicit operator PurchaseOrderId(Guid id)
        => new(id);
}