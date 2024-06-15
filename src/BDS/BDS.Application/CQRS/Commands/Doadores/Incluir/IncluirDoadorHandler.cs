using BDS.Core.Repositories;
using BDS.Core.Entities;
using MediatR;

namespace BDS.Application.CQRS.Commands.Doadores.Incluir
{
    public class IncluirDoadorHandler : IRequestHandler<IncluirDoador, Guid>
    {
        private readonly IDoadorRepository _repository;

        public IncluirDoadorHandler(IDoadorRepository repository)
        {
            _repository = repository;
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
                request.Endereco);

            await _repository.IncluirAsync(doador);


            return doador.Id;

        }
    }
}
