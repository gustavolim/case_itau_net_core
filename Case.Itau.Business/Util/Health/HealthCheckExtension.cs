namespace Case.Itau.Business.Util.Health
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Diagnostics.HealthChecks;
    using System.Reflection;

    public static class HealthCheckExtension
    {
        /// <summary>
        /// Adiciona Health Checks personalizados e dependências adicionais ao IServiceCollection.
        /// </summary>
        /// <param name="services">O IServiceCollection da aplicação.</param>
        /// <param name="dependencies">As dependências adicionais necessárias para os Health Checks.</param>
        /// <returns>O IServiceCollection com os Health Checks e dependências configurados.</returns>
        public static IServiceCollection AddCustomHealthcheckAddDependencies(this IServiceCollection services, List<Dependency> dependencies)
        {
            services.AddCustomHealth();
            services.AddHealthChecks().AddDependencies(dependencies);
            return services;
        }

        public static IApplicationBuilder UseHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health/live");
            app.UseHealthChecks("/health/ready");
            return app;
        }
        public static IServiceCollection AddCustomHealth(this IServiceCollection services)
        {
            IEnumerable<Type> enumerable = from t in Assembly.GetExecutingAssembly().GetExportedTypes()
                                           where typeof(ICallHealthCheck).IsAssignableFrom(t) && !t.IsAbstract
                                           select t;

            foreach (Type t in enumerable)
            {
                services.AddScoped(typeof(ICallHealthCheck), t);
            }

            return services;
        }

        private static IHealthChecksBuilder AddDependencies(this IHealthChecksBuilder builder, List<Dependency> dependencies)
        {
            foreach (Dependency dependency in dependencies)
            {
                string name = dependency.Name.ToLower();

                switch (name)
                {
                    case string url when url.StartsWith("url-"):
                        builder = builder.AddUrlGroup(new Uri(dependency.Url), name: dependency.Name);
                        break;
                    case string sqlite when sqlite.StartsWith("sqllite"):
                        builder = builder.AddSqlite(dependency.ConnectionString, name: "SQLite");
                        break;
                    case string url when url.StartsWith("custom"):
                        builder = builder.AddTypeActivatedCheck<CustomHealthCheck>("Custom Health", failureStatus: HealthStatus.Unhealthy);
                        break;
                    default:
                        break;
                }
            }

            return builder;
        }
    }
}

