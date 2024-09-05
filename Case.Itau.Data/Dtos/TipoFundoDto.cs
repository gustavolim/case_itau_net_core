using LinqToDB.Mapping;


namespace Case.Itau.Data.Dtos
{
    [Table(Name = "TIPO_FUNDO")]
    public class TipoFundoDto
    {
        [PrimaryKey, Identity, Column(Name = "CODIGO"), NotNull]
        public int Codigo { get; set; }
        [Column(Name = "NOME"), NotNull]
        public string Nome { get; set; }
    }
}
