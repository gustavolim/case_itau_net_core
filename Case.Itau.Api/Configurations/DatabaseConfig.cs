using Case.Itau.Data.Contexts;

namespace Case.Itau.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped(_ => new DbCaseItauContext("Data Source=dbCaseItau.s3db"));
        }
    }
}
