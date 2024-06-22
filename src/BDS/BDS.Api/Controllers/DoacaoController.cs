using BDS.Application.CQRS.Commands.Doacoes.Atualizar;
using BDS.Application.CQRS.Commands.Doacoes.Deletar;
using BDS.Application.CQRS.Commands.Doacoes.Incluir;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BDS.Api.Controllers
{
    [Route("api/[controller]")]
    public class DoacaoController : ControllerBase
    {

        private readonly Mediator _mediator;


        public DoacaoController(Mediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> ConsultarAsync()
        {
            return Ok();
        }

        [HttpGet("id")]
        public async Task<IActionResult> ConsultarIdAsync(Guid id)
        {
            return Ok(); 
        }

        [HttpPost]
        public async Task<IActionResult> IncluirAsync([FromBody] IncluirDoacao doacao)
        {
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarDoacao doacao, Guid id)
        {
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeletarAsync([FromBody] DeletarDoacao doacao, Guid id)
        {
            return Ok();
        }
    }
}
