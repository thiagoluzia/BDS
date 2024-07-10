using BDS.Application.CQRS.Commands.Estoque.Incluir;
using BDS.Application.CQRS.Commands.EstoqueSangue.Baixar;
using BDS.Application.CQRS.Queries.EstoqueSangue.ConsultarId;
using BDS.Application.CQRS.Queries.EstoqueSangue.ConsultarTipoSanguineo;
using BDS.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IMediator _mediator;


        public EstoqueController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost]
        public async Task<IActionResult> Registrar(IncluirEstoque incluir)
        {
            var id = await _mediator.Send(incluir);

            if (id == Guid.Empty)
                return NotFound("Doação não consluída.");

            return CreatedAtAction(nameof(ConsultarEstoqueId), new { id }, incluir);

        }


        [HttpGet("{tipo}/{fator}")]
        public async Task<IActionResult> ConsultarTipo(TipoSanguineo tipo, FatorRh fator)
        {
            var query = new ConsultarTipoSanguineo(tipo, fator);

            var tiposanguineo = await _mediator.Send(query);

            if (tiposanguineo is null)
                return NotFound("Não encontrado");

            return Ok(tiposanguineo);
        }


        [HttpGet]
        public async Task<IActionResult> Consultar()
        {
            var query = new ConsultarEstoque();
            var estoque = await _mediator.Send(query);

            if (estoque is null)
                return NotFound("Nenhuma dado no estoque.");

            return Ok(estoque);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarEstoqueId(Guid id)
        {
            var estoqueId = await _mediator.Send(new ConsultarEstoqueId(id));

            if (estoqueId is null)
                return NotFound("Não encontrado");

            return Ok(estoqueId);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> BaixarEstoque(Guid id, BaixarEstoque estoque)
        {
            if (id != estoque.Id)
                return BadRequest("O Id do objeto não pode ser diferente do Id do parametro");

            var existe = await _mediator.Send(new ConsultarEstoqueId(id));

            if (existe is null)
                return NotFound("Item de estoque não encontrado.");

            var atualiza = await _mediator.Send(estoque);

            return NoContent();
        }

    }
}
