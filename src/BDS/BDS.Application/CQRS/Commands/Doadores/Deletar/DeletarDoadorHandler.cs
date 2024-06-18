using BDS.Core.Repositories;
using MediatR;

namespace BDS.Application.CQRS.Commands.Doadores.Deletar
{
    public class DeletarDoadorHandler : IRequestHandler<DeletarDoador, Unit>
    {

        private readonly IDoadorRepository _repository;


        public DeletarDoadorHandler(IDoadorRepository repository)
        {
            _repository = repository;
        }


        public async Task<Unit> Handle(DeletarDoador request, CancellationToken cancellationToken)
        {
            var doador = await  _repository.ConsultarIdAsync(request.Id);

            await _repository.DeletarAsyncId(doador.Id);

            return Unit.Value;
        }

    }
}
