using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDM.RFLocal.Sistema.Monitor.Negocio.Abstracoes.Servicos
{
    public interface IDinamicoServico
    {
        Task<IEnumerable<dynamic>> ObterDadosPorIndicadorAsync(int idIndicador, DateTimeOffset data);
    }
}
