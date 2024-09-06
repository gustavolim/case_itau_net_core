using Case.Itau.Data.Dtos;
using LinqToDB.Mapping;

namespace Case.Itau.Data.Mappings
{
    public class FundosDtoMap : FundoDto
    {
        [Association(ThisKey = nameof(CodigoTipo), OtherKey = nameof(TipoFundosDtoMap.Codigo), CanBeNull = true)]
        public TipoFundosDtoMap TipoFundo { get; set; }

    }
}
