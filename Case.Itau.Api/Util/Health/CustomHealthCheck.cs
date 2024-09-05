using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;

namespace Case.Itau.Api.Util.Health
{
    public class CustomHealthCheck : IHealthCheck
    {
        private readonly ICallHealthCheck _callHealthCheck;

        public CustomHealthCheck(ICallHealthCheck callHealthCheck) 
            => _callHealthCheck = callHealthCheck;

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _callHealthCheck.Validar();
            }
            catch (Exception e)
            {
                Log.Error(e, "Erro na validacao do Health");
                return new HealthCheckResult(HealthStatus.Unhealthy);
            }
        }
    }
}
