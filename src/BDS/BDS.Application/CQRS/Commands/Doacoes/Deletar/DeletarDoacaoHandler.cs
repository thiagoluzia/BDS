using BDS.Core.Repositories;
using MediatR;

namespace BDS.Application.CQRS.Commands.Doacoes.Deletar
{
    public class DeletarDoacaoHandler : IRequestHandler<DeletarDoacao, Unit>
    {

        private readonly IDoadorRepository _doadorRepository;


        public DeletarDoacaoHandler(IDoadorRepository doadorRepository)
        {
            _doadorRepository = doadorRepository;
        }


        public async Task<Unit> Handle(DeletarDoacao request, CancellationToken cancellationToken)
        {
            var doador = await _doadorRepository.ConsultarIdAsync(request.ID);

            await _doadorRepository.DeletarAsyncId(doador.Id);

            return Unit.Value;
        }
    }
}
