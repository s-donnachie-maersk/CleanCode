using CleanCode.PurchaseOrders.Infrastructure.EF;
using CleanCode.PurchaseOrders.Infrastructure.Logging;
using CleanCode.Shared.Abstractions.Commands;
using CleanCode.Shared.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanCode.PurchaseOrders.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPostgres(configuration);
            services.AddQueries();

            services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));
            return services;
        }
    }
}
