using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDM.RFLocal.Sistema.Monitor.Negocio.Abstracoes.Repositorios
{
    public interface IDinamicoRepositorio
    {
        Task<IEnumerable<dynamic>> ExecutarConsultaAsync(string query, object parametros = null);
    }
}
