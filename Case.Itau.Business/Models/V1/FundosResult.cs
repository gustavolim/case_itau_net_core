using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.Itau.Business.Models.V1
{
    public class FundosResult
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public decimal Patrimonio { get; set; }
        public TipoFundoResult TipoFundo { get; set; }
    }
}
