using BDS.Core.Repositories;
using MediatR;

namespace BDS.Application.CQRS.Commands.Doadores.Atualizar
{
    public class AtualizarDoadorHandler : IRequestHandler<AtualizarDoador, Unit>
    {
        private readonly IDoadorRepository _repository;


        public AtualizarDoadorHandler(IDoadorRepository repository)
        {
            _repository = repository;
        }


        public async Task<Unit> Handle(AtualizarDoador request, CancellationToken cancellationToken)
        {
            var doador = await _repository.ConsultarIdAsync(request.Id);

            doador.AtualizarDoador(request.Nome, request.Email, request.Peso, request.Endereco, request.Genero);

            await _repository.AlterarAsync(doador);

            return Unit.Value;

        }
    }
}
