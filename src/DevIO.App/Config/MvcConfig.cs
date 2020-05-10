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
            });
            return services;
        }
    }
}
