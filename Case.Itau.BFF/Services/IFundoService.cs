using Case.Itau.BFF.DTOs;

namespace Case.Itau.BFF.Services
{
    public interface IFundoService
    {
        Task<FundoResponse> GetFundoAsync(string codigo);

        Task<IEnumerable<FundoResponse>> GetFundosAsync();

        Task CreateFundoAsync(FundoRequest fundo);

        Task UpdateFundoAsync(FundoRequest fundo);

        Task DeleteFundoAsync(string codigo);
    }
}
