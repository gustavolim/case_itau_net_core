

using Case.Itau.Data.Dtos;
using Case.Itau.Data.Mappings;
using System.Linq.Expressions;

namespace Case.Itau.Data.Repositories.Fundos
{
    public interface IFundosDao
    {
        Task<List<FundosDtoMap>> ObterFundos(Expression<Func<FundosDtoMap, bool>> predicate);
        Task Inserir(FundoDto fundoDto);
        Task Alterar(FundoDto fundoDto);
        Task Deletar(FundoDto fundoDto);
    }
}
