using System;
using System.Data;

namespace EDM.RFLocal.Sistema.Monitor.Repositorio.Abstracoes
{
    public interface IContexto : IDisposable
    {
        IDbConnection Conexao { get; }
    }
}
