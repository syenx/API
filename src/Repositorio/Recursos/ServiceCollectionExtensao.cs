using EDM.RFLocal.Sistema.Monitor.Negocio.Abstracoes.Repositorios;
using EDM.RFLocal.Sistema.Monitor.Persistencia.Repositorios;
using EDM.RFLocal.Sistema.Monitor.Repositorio.Abstracoes;
using Microsoft.Extensions.DependencyInjection;


namespace EDM.RFLocal.Sistema.Monitor.Repositorio.Recursos
{
    public static class ServiceCollectionExtensao
    {
        public static IServiceCollection ConfigurarRepositorio(this IServiceCollection services)
        {
            
            services.AddScoped<IContexto, Contexto>();
             services.AddScoped<IIndicadorRepositorio, IndicadorRepositorio>();
            services.AddScoped<IDinamicoRepositorio, DinamicoRepositorio>();

            return services;
        }
    }
}
