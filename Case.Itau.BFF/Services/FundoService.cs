using Case.Itau.BFF.DTOs;

namespace Case.Itau.BFF.Services
{
    public class FundoService : IFundoService
    {
        private readonly IFundoApi _fundoApi;
        private readonly ILogger<FundoService> _logger;
        public FundoService(IFundoApi fundoApi, ILogger<FundoService> logger)
        {
            _fundoApi = fundoApi;
            _logger = logger;
        }

        public async Task<FundoResponse> GetFundoAsync(string codigo)
        {
            _logger.LogInformation("TESTE LOG");
            return await _fundoApi.GetFundoAsync(codigo);
        }

        public async Task<IEnumerable<FundoResponse>> GetFundosAsync()
        {
            return await _fundoApi.GetFundosAsync();
        }

        public async Task CreateFundoAsync(FundoRequest fundo)
        {
            await _fundoApi.CreateFundoAsync(fundo);
        }

        public async Task UpdateFundoAsync(FundoRequest fundo)
        {
            await _fundoApi.UpdateFundoAsync(fundo);
        }

        public async Task DeleteFundoAsync(string codigo)
        {
            await _fundoApi.DeleteFundoAsync(codigo);
        }
    }

}
