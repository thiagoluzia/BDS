using BDS.Application.CQRS.Commands.Doadores.Atualizar;
using BDS.Application.CQRS.Commands.Doadores.Deletar;
using BDS.Application.CQRS.Commands.Doadores.Incluir;
using BDS.Application.CQRS.Queries.Doadores.Consultar;
using BDS.Application.CQRS.Queries.Doadores.ConsultarId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoadorController : ControllerBase
    {

        private readonly IMediator _mediator;


        public DoadorController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Consultar()
        {

            var doarores = await _mediator.Send(new ConsultarDoador());

            if(doarores is null)
                return Ok("Nenhum registro encontrado!");
            

            return Ok(doarores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarId(Guid id)
        {
            var doador = new ConsultarDoadorId(id);
            var doadorViewModel = await _mediator.Send(doador);

            if (doadorViewModel is null)
                return NotFound("Doador não encontrado");

            return Ok(doadorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Incluir(IncluirDoador doador)
        {

            var id = await _mediator.Send(doador);

            if (id == Guid.Empty)
                return BadRequest("Erro ao incluir um doador");

            return CreatedAtAction(nameof(ConsultarId), new { id }, doador);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(DeletarDoador doador, Guid id)
        {

            if (doador.Id != id)
                return BadRequest("Id do objeto diferente do Id a ser atualizado");


            var existe = await _mediator.Send(new ConsultarDoadorId(id));
            if (existe is null)
                return NotFound("Doador não encontrado.");

            await _mediator.Send(doador);


            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(AtualizarDoador doador, Guid id)
        {
            return Ok();
        }

        //[HttpGet("{email}")]
        //public async Task<IActionResult> ConsultarEmailAsync(string email)
        //{
        //    return Ok();
        //}
    }
}
