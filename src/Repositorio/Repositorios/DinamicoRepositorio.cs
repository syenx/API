using Dapper;
using EDM.RFLocal.Sistema.Monitor.Negocio.Abstracoes.Repositorios;
using EDM.RFLocal.Sistema.Monitor.Repositorio.Abstracoes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDM.RFLocal.Sistema.Monitor.Persistencia.Repositorios
{
    public class DinamicoRepositorio : IDinamicoRepositorio
    {
        private readonly IContexto _contexto;
        public DinamicoRepositorio(IContexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<IEnumerable<dynamic>> ExecutarConsultaAsync(string query, object parametros = null)
        {
            using (var conexao = _contexto.Conexao)
            {
                return await conexao.QueryAsync(query, parametros);
            }
        }
    }
}
