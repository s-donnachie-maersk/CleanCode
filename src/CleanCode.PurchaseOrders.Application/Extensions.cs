using CleanCode.PurchaseOrders.Domain.Factories;
using CleanCode.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace CleanCode.PurchaseOrders.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<IPurchaseOrderFactory, PurchaseOrderFactory>();
            
            return services;
        }
    }
}
