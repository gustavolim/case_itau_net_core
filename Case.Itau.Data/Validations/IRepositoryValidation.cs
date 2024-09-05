using Microsoft.Extensions.Diagnostics.HealthChecks;


namespace Case.Itau.Data.Validations
{
    public interface IRepositoryValidation
    {
        Task<HealthCheckResult> ValidarRepositorios();
    }
}
