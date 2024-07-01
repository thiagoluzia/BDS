using BDS.Application.CQRS.Commands.Doacoes.Atualizar;
using BDS.Application.CQRS.Commands.Doacoes.Deletar;
using BDS.Application.CQRS.Commands.Doacoes.Incluir;
using BDS.Application.CQRS.Queries.Doacoes.Consultar;
using BDS.Application.CQRS.Queries.Doacoes.ConsultarId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoacaoController : ControllerBase
    {

        private readonly Mediator _mediator;


        public DoacaoController(Mediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public  async Task<IActionResult> ConsultarAsync()
        {

            var doacoes = await _mediator.Send(new ConsultarDoacao());

            if(doacoes is null)
                return NotFound("Nenhum registro encontrado!");
            
            return Ok(doacoes);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarIdAsync(Guid id)
        {

            var doacao = new ConsultarDoacaoId(id);

            var doacaoVielModel = await _mediator.Send(doacao);

            if (doacaoVielModel is null)
                return NotFound("Nenhum registro encontrado!");

            
            return Ok(doacaoVielModel); 

        }

        [HttpPost]
        public async Task<IActionResult> IncluirAsync(IncluirDoacao doacao)
        {
            var id = await _mediator.Send(doacao);

            return CreatedAtAction(nameof(ConsultarIdAsync), id);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAsync(AtualizarDoacao doacao, Guid id)
        {
            if (doacao.Id != id)
                return BadRequest("Id do objeto diferente do Id a ser atualizado"); 

            await _mediator.Send(doacao);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(DeletarDoacao doacao, Guid id)
        {
            return Ok();
        }
    }
}
