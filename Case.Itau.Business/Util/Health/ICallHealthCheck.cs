using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Case.Itau.Business.Util.Health
{
    public interface ICallHealthCheck
    {
        Task<HealthCheckResult> Validar();
    }
}
