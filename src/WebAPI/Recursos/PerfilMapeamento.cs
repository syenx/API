using AutoMapper;
using EDM.RFLocal.Sistema.Monitor.Negocio.Entidades;
using EDM.RFLocal.Sistema.Monitor.WebAPI.Fronteira;
using EDM.RFLocal.Sistema.Monitor.WebAPI.Fronteira.Entrada;
using EDM.RFLocal.Sistema.Monitor.WebAPI.Fronteira.Saida;

namespace EDM.RFLocal.Sistema.Monitor.WebAPI.Recursos
{
    public class PerfilMapeamento : Profile
    {
        public PerfilMapeamento()
        {
            CreateMap<Indicador, IndicadorDTO>();
            CreateMap<Indicador, IndicadorDTOOut>();
            CreateMap<IndicadorDTOIn, Indicador>();
        }
    }
}
