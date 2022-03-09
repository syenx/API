using EDM.RFLocal.Sistema.Monitor.Negocio.Enums;

namespace EDM.RFLocal.Sistema.Monitor.WebAPI.Fronteira
{
    public class IndicadorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoUI Tipo { get; set; }
    }
}
