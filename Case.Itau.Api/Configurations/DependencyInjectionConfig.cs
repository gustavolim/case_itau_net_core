using Case.Itau.Business.Services.V1.Fundos;
using Case.Itau.Business.Services.V1.Login;
using Case.Itau.Data.Repositories.Fundos;
using Case.Itau.Data.Validations;

namespace Case.Itau.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            #region {API}
            //services.AddTransient<HttpLogHandler>();
            #endregion

            #region {Business}
            services.AddScoped<IFundosServices, FundosServices>();
            services.AddScoped<ILogin, Login>();

            #endregion

            #region {Data}
            services.AddScoped<IRepositoryValidation, RepositoryValidation>();
            services.AddScoped<IFundosDao, FundosDao>();
            #endregion
        }
    }
}
