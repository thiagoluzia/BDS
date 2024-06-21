using BDS.Core.Repositories;
using BDS.Core.Entities;
using MediatR;
using BDS.Core.Services.Interfaces;

namespace BDS.Application.CQRS.Commands.Doadores.Incluir
{
    public class IncluirDoadorHandler : IRequestHandler<IncluirDoador, Guid>
    {

        private readonly IDoadorRepository _repository;
        private readonly IDoadorService _service;

        public IncluirDoadorHandler(IDoadorRepository repository, IDoadorService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<Guid> Handle(IncluirDoador request, CancellationToken cancellationToken)
        {

            var doador = new Doador(
                request.Nome,
                request.Email,
                request.DataNascimento,
                request.Genero,
                request.Peso,
                request.TipoSanquineo,
                request.Fator,
                request.Endereco,
                _service);

            await _repository.IncluirAsync(doador);


            return doador.Id;

        }
    }
}
