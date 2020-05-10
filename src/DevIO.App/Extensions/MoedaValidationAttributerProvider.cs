using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.Extensions
{
    public class MoedaValidationAttributerProvider : IValidationAttributeAdapterProvider
    {
        private readonly IValidationAttributeAdapterProvider _baseProvider = new ValidationAttributeAdapterProvider();
        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            if (attribute is MoedaAttribute moedaAttribute) return new MoedaAttributeAdapter(moedaAttribute, stringLocalizer);

            return _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}