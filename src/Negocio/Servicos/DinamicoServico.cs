using EDM.RFLocal.Sistema.Monitor.Negocio.Abstracoes.Repositorios;
using EDM.RFLocal.Sistema.Monitor.Negocio.Abstracoes.Servicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDM.RFLocal.Sistema.Monitor.Negocio.Servicos
{
    public class DinamicoServico : IDinamicoServico
    {
        private readonly IDinamicoRepositorio _repositorio;
        private readonly IIndicadorRepositorio _indicadorRepositorio;

        public DinamicoServico(IDinamicoRepositorio repositorio, IIndicadorRepositorio indicadorRepositorio)
        {
            _repositorio = repositorio;
            _indicadorRepositorio = indicadorRepositorio;
        }

        public async Task<IEnumerable<dynamic>> ObterDadosPorIndicadorAsync(int idIndicador, DateTimeOffset data)
        {
            var indicador = await _indicadorRepositorio.ObterAsync(idIndicador);
            if (indicador == null)
                throw new Exception("Indicador não encontrado");

            return await _repositorio.ExecutarConsultaAsync(indicador.SqlConsulta, new { Data = data });
        }
    }
}
