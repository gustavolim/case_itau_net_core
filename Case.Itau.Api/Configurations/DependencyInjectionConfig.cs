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

            #endregion

            #region {Data}

            #endregion
        }
    }
}
