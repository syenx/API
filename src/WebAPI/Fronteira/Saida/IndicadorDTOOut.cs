using EDM.RFLocal.Sistema.Monitor.Negocio.Enums;

namespace EDM.RFLocal.Sistema.Monitor.WebAPI.Fronteira.Saida
{
    public class IndicadorDTOOut
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SQLConsulta { get; set; }
        public TipoUI Tipo { get; set; }
        public bool Ativo { get; set; }
    }
}
