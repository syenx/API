using EDM.RFLocal.Sistema.Monitor.Negocio.Enums;

namespace EDM.RFLocal.Sistema.Monitor.Negocio.Entidades
{
    public class Indicador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoUI Tipo { get; set; }
        public string SqlConsulta { get; set; }
        public bool Ativo { get; set; }
    }
}
