using CleanCode.PurchaseOrders.Domain.Exceptions;

namespace CleanCode.PurchaseOrders.Domain.ValueObjects;

public record PurchaseOrderNumber
{
    public string Value { get; }

    public PurchaseOrderNumber(string value)
    {
        if (value == string.Empty)
        {
            throw new EmptyPurchaseOrderNumberException();
        }
            
        Value = value;
    }
        
    public static implicit operator string(PurchaseOrderNumber poNumber)
        => poNumber.Value;

    public static implicit operator PurchaseOrderNumber(string poNumber)
        => new(poNumber);
}