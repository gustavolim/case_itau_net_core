using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
