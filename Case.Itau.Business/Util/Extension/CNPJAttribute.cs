using System;
using System.ComponentModel.DataAnnotations;

namespace Case.Itau.Business.Util.Extension
{
    public class CNPJAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !IsCnpjValid(value.ToString()))
            {
                return new ValidationResult("CNPJ inválido.");
            }
            return ValidationResult.Success;
        }

        private bool IsCnpjValid(string cnpj)
        {
            // Lógica de validação de CNPJ (simples para exemplificar)
            return cnpj.Length == 14;
        }
    }

    public static class CNPJFormatter
    {
        public static string Format(string cnpj)
        {
            if (cnpj.Length == 14)
            {
                return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
            }
            return cnpj;
        }
    }
}