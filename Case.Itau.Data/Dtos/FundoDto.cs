using LinqToDB.Mapping;

namespace Case.Itau.Data.Dtos
{
    [Table(Name = "FUNDO")]
    public class FundoDto
    {
        [PrimaryKey, Identity, Column(Name = "CODIGO"), NotNull]
        public string Codigo { get; set; }
        [Column(Name = "NOME"), NotNull]

        public string Nome { get; set; }

        [Column(Name = "CNPJ"), NotNull]
        public string CNPJ { get; set; }

        [Column(Name = "CODIGO_TIPO"), NotNull]
        public int CodigoTipo { get; set; }

        [Column(Name = "PATRIMONIO"), Nullable]
        public decimal Patrimonio { get; set; }

        //[Association(ThisKey = "Codigo", OtherKey = "Codigo", CanBeNull = false)]
        //public TipoFundoDto TipoFundo { get; set; }

    }
}
