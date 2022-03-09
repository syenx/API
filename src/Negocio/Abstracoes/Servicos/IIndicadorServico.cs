using EDM.RFLocal.Sistema.Monitor.Negocio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDM.RFLocal.Sistema.Monitor.Negocio.Abstracoes.Servicos
{
    public interface IIndicadorServico
    {
        Task AdicionarAsync(Indicador entidade);
        Task<bool> AtualizarAsync(Indicador entidade);
        Task<bool> RemoverAsync(Indicador entidade);
        Task<Indicador> ObterAsync(int id);
        Task<IEnumerable<Indicador>> ObterTodosAsync();
        Task<IEnumerable<Indicador>> ObteTodosAtivosAsync();
        Task<bool> AtivarDesativarAsync(Indicador entidade, bool ativar);
    }
}
