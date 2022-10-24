namespace CleanCode.PurchaseOrders.Infrastructure.EF.Options
{
    public class PostgresOptions
    {
        public const string Postgres = "Postgres";

        public string ConnectionString { get; set; } = string.Empty;
    }
}
