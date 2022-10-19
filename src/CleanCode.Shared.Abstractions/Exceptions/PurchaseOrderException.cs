namespace CleanCode.Shared.Abstractions.Exceptions
{
    public abstract class PurchaseOrderException : Exception
    {
        protected PurchaseOrderException(string message) : base(message)
        {
        }
    }
}
