using EDM.RFLocal.Sistema.Monitor.Negocio.Enums;

namespace EDM.RFLocal.Sistema.Monitor.WebAPI.Fronteira.Entrada
{
    public class IndicadorDTOIn
    {
        public string Nome { get; set; }
        public string SQLConsulta { get; set; }
        public TipoUI Tipo { get; set; }
        public bool Ativo { get; set; }
    }
}
