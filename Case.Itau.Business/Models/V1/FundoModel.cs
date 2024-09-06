

namespace Case.Itau.Business.Models.V1
{
    public class FundoModel
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public int CodigoTipo { get; set; }
        public decimal Patrimonio { get; set; }
        public TipoFundoModel TipoFundo { get; set; }
    }
}
