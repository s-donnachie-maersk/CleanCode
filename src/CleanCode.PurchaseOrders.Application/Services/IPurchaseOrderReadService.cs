namespace CleanCode.PurchaseOrders.Application.Services
{
    public interface IPurchaseOrderReadService
    {
        Task<bool> ExistsByPurchaseOrderNumberAsync(string purchaseOrderNumber);
    }
}
