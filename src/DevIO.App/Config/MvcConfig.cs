using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.App.Config
{
    public static class MvcConfig
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services)
        {
            services.AddMvc(o =>
            {
                //Bind da mensagem que aparece no validation no js
                o.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y)
                    => "O valor preenchido é inválido para este campo.");

                //Validando automaticamente os RequestToken em todas as view
                o.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            return services;
        }
    }
}
