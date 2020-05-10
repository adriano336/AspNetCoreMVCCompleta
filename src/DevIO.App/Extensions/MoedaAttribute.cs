using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace DevIO.App.Extensions
{
    public class MoedaAttribute : ValidationAttribute
    {
        //Validação server
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var moeda = Convert.ToDecimal(value, new CultureInfo("pt-BR"));
            }
            catch (Exception)
            {
                return new ValidationResult("Moeda em formato inválido.");
            }

            return base.IsValid(value, validationContext);
        }
    }
}
