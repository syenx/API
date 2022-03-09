using AutoMapper;
using EDM.RFLocal.Sistema.Monitor.Negocio.Abstracoes.Servicos;
using EDM.RFLocal.Sistema.Monitor.Negocio.Entidades;
using EDM.RFLocal.Sistema.Monitor.WebAPI.Fronteira.Entrada;
using EDM.RFLocal.Sistema.Monitor.WebAPI.Fronteira.Saida;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDM.RFLocal.Sistema.Monitor.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndicadorController : ControllerBase
    {
        private readonly ILogger<IndicadorController> _logger;
        private readonly IMapper _map;

        public IndicadorController(ILogger<IndicadorController> logger,
            IMapper map)
        {
            _logger = logger;
            _map = map;
        }

        [HttpGet]
        public virtual async Task<IActionResult> ObterTodos([FromServices] IIndicadorServico servico)
        {
            var indicadores = await servico.ObterTodosAsync();
            var saida = _map.Map<List<IndicadorDTOOut>>(indicadores);
            return Ok(saida);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Obter([FromRoute] int id, [FromServices] IIndicadorServico servico)
        {
            var indicador = await servico.ObterAsync(id);
            var saida = _map.Map<IndicadorDTOOut>(indicador);
            return Ok(saida);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Adicionar([FromBody] IndicadorDTOIn dtoEntrada, [FromServices] IIndicadorServico servico)
        {
            var entidade = _map.Map<Indicador>(dtoEntrada);
            await servico.AdicionarAsync(entidade);
            var saida = _map.Map<IndicadorDTOOut>(entidade);
            return Ok(saida);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] IndicadorDTOIn dtoEntrada, [FromServices] IIndicadorServico servico)
        {
            var entidade = _map.Map<Indicador>(dtoEntrada);
            entidade.Id = id;
            var resultado = await servico.AtualizarAsync(entidade);
            return resultado ? Ok() : StatusCode(500);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Remover([FromRoute] int id, [FromServices] IIndicadorServico servico)
        {
            var entidade = Activator.CreateInstance<Indicador>();
            entidade.Id = id;
            var resultado = await servico.RemoverAsync(entidade);
            return resultado ? Ok() : StatusCode(500);
        }

        [HttpPatch("{id}/ativar")]
        public virtual async Task<IActionResult> Ativar([FromRoute] int id, [FromServices] IIndicadorServico servico)
        {
            var entidade = Activator.CreateInstance<Indicador>();
            entidade.Id = id;
            var resultado = await servico.AtivarDesativarAsync(entidade, true);
            return resultado ? Ok() : StatusCode(500);
        }

        [HttpPatch("{id}/desativar")]
        public virtual async Task<IActionResult> Desativar([FromRoute] int id, [FromServices] IIndicadorServico servico)
        {
            var entidade = Activator.CreateInstance<Indicador>();
            entidade.Id = id;
            var resultado = await servico.AtivarDesativarAsync(entidade, false);
            return resultado ? Ok() : StatusCode(500);
        }
    }
}
