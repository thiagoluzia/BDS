using BDS.Application.Abstractions.External.ViaCEP;
using Microsoft.AspNetCore.Mvc;

namespace BDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IViaCepService _service;


        public EnderecoController(IViaCepService service)
        {
            _service = service;
        }


        [HttpGet("cep")]
        public async Task<IActionResult> ConsultarCep(string cep)
        {
            if (string.IsNullOrEmpty(cep))
                return BadRequest("O cep não pode ser nulo ou vazio.");

            var cepFormatado = FormataCep(cep);

            if (cepFormatado.Length < 8)
                return BadRequest("O cep não pode ser menor que 8 digitos.");

            var endereco = await _service.ConsultarCepAsync(cepFormatado);

            if (endereco is null)
                return BadRequest("Endereço não encontrado na base dos correios.");



            return Ok(endereco);
        }

        protected string FormataCep(string cep)
        {
            return cep.Trim().Replace("-", "".Replace(".", ""));
        }
    }
}
