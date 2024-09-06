using Case.Itau.Data.Contexts;
using Case.Itau.Data.Dtos;
using Case.Itau.Data.Mappings;
using LinqToDB;
using System;
using System.Linq.Expressions;

namespace Case.Itau.Data.Repositories.Fundos
{
    public class FundosDao(DbCaseItauContext context) : IFundosDao
    {
        private readonly DbCaseItauContext _context = context;

        public Task Alterar(FundosDtoMap fundoDto) =>
            _context.UpdateAsync(fundoDto);


        public Task Deletar(Expression<Func<FundosDtoMap, bool>> predicate) =>
        _context.Fundos
            .Where(predicate)
            .DeleteAsync();

        public Task Inserir(FundosDtoMap fundoDto) => 
            _context.InsertAsync(fundoDto);

        public Task<FundosDtoMap> ObterFundo(Expression<Func<FundosDtoMap, bool>> predicate) =>
            _context.Fundos
                .LoadWith(x => x.TipoFundo)
                .Where(predicate)
                .OrderByDescending(x => x.Codigo)
                .FirstOrDefaultAsync();

        public Task<List<FundosDtoMap>> ObterFundos(Expression<Func<FundosDtoMap, bool>> predicate) =>
            _context.Fundos
                .LoadWith(x => x.TipoFundo)
                .Where(predicate)
                .OrderByDescending(x => x.Codigo)
                .ToListAsync();

    }
}
