using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Globalization;

namespace DevIO.App.Config
{
    public static class GlobalizationConfig
    {
        public static IApplicationBuilder UseGlobalizationBuilder(this IApplicationBuilder app)            
        {
            //Globalização
            var defaultCulture = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };

            return app;
        }
    }
}
