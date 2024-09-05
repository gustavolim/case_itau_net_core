using Case.Itau.Data.Dtos;
using Case.Itau.Data.Mappings;
using LinqToDB;
using LinqToDB.Data;


namespace Case.Itau.Data.Contexts
{
    public class DbCaseItauContext : DataConnection
    {
        public DbCaseItauContext(string connectionString) : base(ProviderName.SQLite, connectionString)
        {
        }

        public ITable<TipoFundosDtoMap> TipoFundos => this.GetTable<TipoFundosDtoMap>();
        public ITable<FundosDtoMap> Fundos => this.GetTable<FundosDtoMap>();

    }
}