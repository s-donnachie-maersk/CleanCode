using CleanCode.PurchaseOrders.Domain.Repositories;
using CleanCode.PurchaseOrders.Infrastructure.EF.Contexts;
using CleanCode.PurchaseOrders.Infrastructure.EF.Options;
using CleanCode.PurchaseOrders.Infrastructure.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanCode.PurchaseOrders.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPurchaseOrderRepository, PostgresPurchaseOrderRepository>();
            //services.AddScoped<IPackingListReadService, PostgresPackingListReadService>();
            
            var options = configuration.GetOptions<PostgresOptions>("Postgres");
            //services.AddDbContext<ReadDbContext>(ctx => 
            //    ctx.UseNpgsql(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(ctx => 
                ctx.UseNpgsql(options.ConnectionString));

            return services;
        }
    }
}
