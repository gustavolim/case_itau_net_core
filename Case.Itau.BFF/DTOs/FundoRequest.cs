using Case.Itau.BFF.Util.Extension;
using System.ComponentModel.DataAnnotations;

namespace Case.Itau.BFF.DTOs
{
    public class FundoRequest
    {
        [Required(ErrorMessage = "O campo é obrigatório.")]
        [StringLength(20, ErrorMessage = "O campo deve ter no máximo 20 caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [CNPJ, Required(ErrorMessage = "O campo é obrigatório.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int CodigoTipo { get; set; }
        public decimal Patrimonio { get; set; }
    }
}
