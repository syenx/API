using EDM.RFLocal.Sistema.Monitor.Negocio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDM.RFLocal.Sistema.Monitor.Negocio.Abstracoes.Repositorios
{
    public interface IIndicadorRepositorio
    {
        Task AdicionarAsync(Indicador entidade);
        Task<bool> AtualizarAsync(Indicador entidade);
        Task<bool> RemoverAsync(Indicador entidade);
        Task<Indicador> ObterAsync(int Id);
        Task<IEnumerable<Indicador>> ObterTodosAsync();
        Task<IEnumerable<Indicador>> ObterTodosAtivosAsync();
        Task<bool> AtivarDesativarAsync(Indicador entidade, bool ativar);
    }
}
