using Case.Itau.Api.Util.Health;
using Case.Itau.Data.Validations;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
//using HeathChecks.UI.Client;

namespace Case.Itau.Api.Configurations
{
    public static class HealthCheckConfig
    {
        public static void AddHelthCheckConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var dependencias = new List<Dependency>();

            new ConfigureFromConfigurationOptions<List<Dependency>>(
                configuration.GetSection("HealthCheck"))
                .Configure(dependencias);

            dependencias = dependencias.OrderBy(d => d.Name).ToList();

            services.AddCustomHealthcheckAddDependencies(dependencias);

            services.AddHealthChecksUI(setup =>
            {
                setup.UseApiEndpointHttpMessageHandler(sp =>
                {
                    return new HttpClientHandler
                    {
                        ClientCertificateOptions = ClientCertificateOption.Manual,
                        ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => { return true; }
                    };
                });
            }).AddInMemoryStorage();
        }

        public static void UseHealthCheckSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseHealthChecks("/healthchecks/ready", new HealthCheckOptions
            {
                Predicate = p => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(opt => { opt.UIPath = "/dashboard"; });
        }
        public class CallHealthCheck : ICallHealthCheck
        {
            private readonly IRepositoryValidation _repositoryValidation;

            public CallHealthCheck(IRepositoryValidation repositoryValidation) => _repositoryValidation = repositoryValidation;

            public async Task<HealthCheckResult> Validar()
            {
                try
                {
                    return await _repositoryValidation.ValidarRepositorios();
                }
                catch (Exception)
                {
                    return new HealthCheckResult(HealthStatus.Degraded);
                }
            }
        }
    }
}
