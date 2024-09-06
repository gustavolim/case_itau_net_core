using Case.Itau.Business.Models.V1;


namespace Case.Itau.Business.Services.V1.Fundos
{
    public interface IFundosServices
    {
        Task<List<FundosResult>> ObterFundos();
        Task<FundosResult> ObterFundo(string codigo);
        Task Inserir(FundoModel fundoDto);
        Task Alterar(FundoModel fundoDto);
        Task Deletar(string codigo);
    }
}
