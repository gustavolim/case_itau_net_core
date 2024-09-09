namespace Case.Itau.BFF.Services
{
    using Case.Itau.BFF.DTOs;
    using Refit;

    public interface IFundoApi
    {
        [Get("/api/v1/fundo/{codigo}")]
        Task<FundoResponse> GetFundoAsync(string codigo);

        [Get("/api/v1/fundo")]
        Task<IEnumerable<FundoResponse>> GetFundosAsync();

        [Post("/api/v1/fundo")]
        Task CreateFundoAsync([Body] FundoRequest fundo);

        [Put("/api/v1/fundo")]
        Task UpdateFundoAsync([Body] FundoRequest fundo);

        [Delete("/api/v1/fundo/{codigo}")]
        Task DeleteFundoAsync(string codigo);
    }

}
