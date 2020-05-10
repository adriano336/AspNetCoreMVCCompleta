using DevIO.App.Extensions;
using DevIO.Business.Interface;
using DevIO.Data.Context;
using DevIO.Data.Repository;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.App.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection InjetarDependencias(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            services.AddScoped<MeuDbContext>();
            services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributerProvider>();
            return services;
        }
    }
}
