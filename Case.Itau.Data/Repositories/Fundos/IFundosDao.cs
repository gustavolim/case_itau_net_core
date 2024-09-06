

using Case.Itau.Data.Dtos;
using Case.Itau.Data.Mappings;
using System.Linq.Expressions;

namespace Case.Itau.Data.Repositories.Fundos
{
    public interface IFundosDao
    {
        Task<List<FundosDtoMap>> ObterFundos(Expression<Func<FundosDtoMap, bool>> predicate);
        Task<FundosDtoMap> ObterFundo(Expression<Func<FundosDtoMap, bool>> predicate);
        Task Inserir(FundosDtoMap fundoDto);
        Task Alterar(FundosDtoMap fundoDto);
        Task Deletar(Expression<Func<FundosDtoMap, bool>> predicate);
    }
}
