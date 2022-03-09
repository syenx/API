using AutoMapper;
using EDM.RFLocal.Sistema.Monitor.Negocio.Abstracoes.Servicos;
using EDM.RFLocal.Sistema.Monitor.WebAPI.Fronteira;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IMapper _map;

        public DashboardController(ILogger<DashboardController> logger, IMapper map)
        {
            _logger = logger;
            _map = map;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAtivosAsync([FromServices] IIndicadorServico servico)
        {
            var indicadores = await servico.ObteTodosAtivosAsync();
            var dtos = _map.Map<IEnumerable<IndicadorDTO>>(indicadores);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterDadosPorIndicadorAsync([FromRoute] int id,
            [FromQuery] DateTimeOffset data,
            [FromServices] IDinamicoServico servico)
        {
            var resultado = await servico.ObterDadosPorIndicadorAsync(id, data);
            return Ok(resultado);
        }
    }
}
