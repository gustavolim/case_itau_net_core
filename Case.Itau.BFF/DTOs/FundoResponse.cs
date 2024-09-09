namespace Case.Itau.BFF.DTOs
{
    public class FundoResponse
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public decimal Patrimonio { get; set; }
        public int CodigoTipo { get; set; }
        public TipoFundoResponse TipoFundo { get; set; }
    }
}
