using Dapper;
using EDM.RFLocal.Sistema.Monitor.Negocio.Abstracoes.Repositorios;
using EDM.RFLocal.Sistema.Monitor.Negocio.Entidades;
using EDM.RFLocal.Sistema.Monitor.Repositorio.Abstracoes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDM.RFLocal.Sistema.Monitor.Persistencia.Repositorios
{
    public class IndicadorRepositorio : IIndicadorRepositorio
    {
        private const string TABELA = "monitoria_edm.Indicadores";

        private readonly IContexto _contexto;
        public IndicadorRepositorio(IContexto contexto)
        {

            _contexto = contexto;
        }

        public async Task<Indicador> ObterAsync(int Id)
        {
            var sql = $"SELECT * FROM {TABELA} WHERE id = {Id}";

            using (var conexao = _contexto.Conexao)
            {
                var resultado = await conexao.QueryAsync<Indicador>(sql);
                return resultado.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Indicador>> ObterTodosAsync()
        {
            var sql = $"SELECT * FROM {TABELA}";

            using (var conexao = _contexto.Conexao)
            {
                return await conexao.QueryAsync<Indicador>(sql);
            }
        }

        public async Task<IEnumerable<Indicador>> ObterTodosAtivosAsync()
        {
            var sql = $"SELECT * FROM {TABELA} WHERE ativo = true";

            using (var conexao = _contexto.Conexao)
            {
                return await conexao.QueryAsync<Indicador>(sql);
            }
        }

        public async Task AdicionarAsync(Indicador entidade)
        {
            var sql = $"INSERT INTO {TABELA} (nome, tipo, sqlConsulta, ativo) VALUES(@Nome, @Tipo, @SqlConsulta, @Ativo)";
            using (var conexao = _contexto.Conexao)
            {
                await conexao.ExecuteAsync(sql, entidade);
            }
        }

        public async Task<bool> AtualizarAsync(Indicador entidade)
        {
            var sql = $"UPDATE {TABELA} SET nome = @Nome, tipo = @Tipo, sqlConsulta = @SqlConsulta, ativo = @Ativo WHERE id = @Id";
            using (var conexao = _contexto.Conexao)
            {
                var qtd = await conexao.ExecuteAsync(sql, entidade);
                return qtd > 0;
            }
        }

        public async Task<bool> RemoverAsync(Indicador entidade)
        {
            string sql = string.Format($"DELETE FROM {TABELA} WHERE id = {entidade.Id}");
            using (var conexao = _contexto.Conexao)
            {
                var qtd = await conexao.ExecuteAsync(sql);
                return qtd > 0;
            }
        }

        public async Task<bool> AtivarDesativarAsync(Indicador entidade, bool ativar)
        {
            var sql = $"UPDATE {TABELA} SET ativo = @Ativar WHERE id = @Id";
            using (var conexao = _contexto.Conexao)
            {
                var qtd = await conexao.ExecuteAsync(sql, new { Id = entidade.Id, Ativar = ativar });
                return qtd > 0;
            }
        }
    }
}
