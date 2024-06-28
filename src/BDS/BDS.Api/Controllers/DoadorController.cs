using BDS.Application.CQRS.Commands.Doadores.Atualizar;
using BDS.Application.CQRS.Commands.Doadores.Deletar;
using BDS.Application.CQRS.Commands.Doadores.Incluir;
using BDS.Application.CQRS.Queries.Doacoes.ConsultarId;
using BDS.Application.CQRS.Queries.Doadores.Consultar;
using BDS.Application.CQRS.Queries.Doadores.ConsultarId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BDS.Api.Controllers
{
    [Route("api/[controller]")]
    public class DoadorController : ControllerBase
    {

        private readonly IMediator _mediator;


        public DoadorController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> ConsultarAsync()
        {

            var doarores = await _mediator.Send(new ConsultarDoador());

            if(doarores is null)
            {
                return Ok("Nenhumregistro encontrado!");
            }

            return Ok(doarores);
        }

        [HttpGet("id")]
        public async Task<IActionResult> ConsultarIdAsync(Guid id)
        {
            var doador = new ConsultarDoadorId(id);
            var doadorViewModel = await _mediator.Send(doador);

            if (doadorViewModel is null)
                return NotFound("Doador não encontrado");

            return Ok(doadorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> IncluirAsync([FromBody] IncluirDoador doador)
        {

            var id = await _mediator.Send(doador);

            //return CreatedAtAction(nameof(ConsultarIdAsync), new { id }, doador);
            return CreatedAtAction(nameof(ConsultarIdAsync),  id );

        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeletarAsync([FromBody] DeletarDoador doador, Guid Id)
        {
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarDoador doador, Guid id)
        {
            return Ok();
        }

        [HttpGet("email")]
        public async Task<IActionResult> ConsultarEmailAsync(string email)
        {
            return Ok();
        }
    }
}
