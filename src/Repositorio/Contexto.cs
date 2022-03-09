using EDM.RFLocal.Sistema.Monitor.Repositorio.Abstracoes;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;

namespace EDM.RFLocal.Sistema.Monitor.Repositorio
{
    public class Contexto : IContexto
    {
        private readonly IConfiguration _configuracao;
        public Contexto(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        public IDbConnection Conexao
        {
            get
            {
                return new MySqlConnection(_configuracao.GetConnectionString("BaseMySql"));
            }
        }
        public void Dispose()
        {
            Conexao.Dispose();
        }
    }
}
