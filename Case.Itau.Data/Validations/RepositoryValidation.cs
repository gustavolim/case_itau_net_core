using Case.Itau.Data.Contexts;
using LinqToDB;
using Microsoft.Extensions.Diagnostics.HealthChecks;



namespace Case.Itau.Data.Validations
{
    public class RepositoryValidation : IRepositoryValidation
    {
        private readonly DbCaseItauContext dbCaseItauContext;

        public RepositoryValidation(DbCaseItauContext dbCaseItauContext) => this.dbCaseItauContext = dbCaseItauContext;

        private async Task<HealthCheckResult> ValidarSqlite()
        {
            _ = await this.dbCaseItauContext.TipoFundos.Where(t=> t.Codigo == 1).FirstOrDefaultAsync();

            return new HealthCheckResult(HealthStatus.Healthy);
        }
        public async Task<HealthCheckResult> ValidarRepositorios()
        {
            try
            {
                ValidarSqlite().Wait();
                return new HealthCheckResult(HealthStatus.Healthy);
            }
            catch (Exception)
            {

                return new HealthCheckResult(HealthStatus.Degraded);    
            }
            
        }
    }
}
