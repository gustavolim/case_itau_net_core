using Case.Itau.Data.Contexts;
using Case.Itau.Data.Dtos;
using Case.Itau.Data.Mappings;
using LinqToDB;
using System.Linq.Expressions;

namespace Case.Itau.Data.Repositories.Fundos
{
    public class FundosDao(DbCaseItauContext context) : IFundosDao
    {
        private readonly DbCaseItauContext _context = context;

        public Task Alterar(FundoDto fundoDto) =>
            _context.InsertAsync(fundoDto);


        public Task Deletar(FundoDto fundoDto) =>
            _context.DeleteAsync(fundoDto);

        public Task Inserir(FundoDto fundoDto) => 
            _context.InsertAsync(fundoDto);

        public Task<List<FundosDtoMap>> ObterFundos(Expression<Func<FundosDtoMap, bool>> predicate) =>
            _context.Fundos
                .LoadWith(x => x.TipoFundo)
                .Where(predicate)
                .OrderByDescending(x => x.Codigo)
                .ToListAsync();

    }
}
