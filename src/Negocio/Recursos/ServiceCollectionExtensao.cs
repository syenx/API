using EDM.RFLocal.Sistema.Monitor.Negocio.Abstracoes.Servicos;
using EDM.RFLocal.Sistema.Monitor.Negocio.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace EDM.RFLocal.Sistema.Monitor.Negocio.Recursos
{
    public static class ServiceCollectionExtensao
    {
        public static IServiceCollection ConfigurarNegocio(this IServiceCollection services)
        {
            services.AddScoped<IIndicadorServico, IndicadorServico>();
            services.AddScoped<IDinamicoServico, DinamicoServico>();

            return services;
        }
    }
}
