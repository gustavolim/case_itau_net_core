using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Case.Itau.Api.Util.Health
{
    public interface ICallHealthCheck
    {
        Task<HealthCheckResult> Validar();
    }
}
