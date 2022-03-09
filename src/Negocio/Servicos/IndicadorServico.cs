using EDM.RFLocal.Sistema.Monitor.Negocio.Abstracoes.Repositorios;
using EDM.RFLocal.Sistema.Monitor.Negocio.Abstracoes.Servicos;
using EDM.RFLocal.Sistema.Monitor.Negocio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDM.RFLocal.Sistema.Monitor.Negocio.Servicos
{
    public class IndicadorServico : IIndicadorServico
    {
        private readonly IIndicadorRepositorio _repositorio;
        public IndicadorServico(IIndicadorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Task AdicionarAsync(Indicador entidade)
        {
            return _repositorio.AdicionarAsync(entidade);
        }

        public Task<bool> AtualizarAsync(Indicador entidade)
        {
            return _repositorio.AtualizarAsync(entidade);
        }

        public Task<Indicador> ObterAsync(int id)
        {
            return _repositorio.ObterAsync(id);
        }

        public Task<IEnumerable<Indicador>> ObterTodosAsync()
        {
            return _repositorio.ObterTodosAsync();
        }

        public Task<IEnumerable<Indicador>> ObteTodosAtivosAsync()
        {
            return _repositorio.ObterTodosAtivosAsync();
        }

        public Task<bool> RemoverAsync(Indicador entidade)
        {
            return _repositorio.RemoverAsync(entidade);
        }

        public Task<bool> AtivarDesativarAsync(Indicador entidade, bool ativar)
        {
            return _repositorio.AtivarDesativarAsync(entidade, ativar);
        }
    }
}
