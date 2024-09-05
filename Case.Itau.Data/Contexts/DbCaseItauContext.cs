using Case.Itau.Data.Dtos;
using LinqToDB;
using LinqToDB.Data;


namespace Case.Itau.Data.Contexts
{
    public class DbCaseItauContext : DataConnection
    {
        public DbCaseItauContext(string connectionString) : base(ProviderName.SQLite, connectionString)
        {
        }

        public ITable<TipoFundoDto> TipoFundos => this.GetTable<TipoFundoDto>();
        public ITable<FundoDto> Fundos => this.GetTable<FundoDto>();

    }
}