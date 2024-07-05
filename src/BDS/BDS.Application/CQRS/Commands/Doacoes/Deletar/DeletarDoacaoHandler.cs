using BDS.Core.Entities;
using BDS.Core.Repositories;
using MediatR;

namespace BDS.Application.CQRS.Commands.Doacoes.Deletar
{
    public class DeletarDoacaoHandler : IRequestHandler<DeletarDoacao, Unit>
    {

        private readonly IDoacaoRepository _doacaoRepository;


        public DeletarDoacaoHandler(IDoacaoRepository doacaoRepository)
        {
            _doacaoRepository = doacaoRepository;
        }


        public async Task<Unit> Handle(DeletarDoacao request, CancellationToken cancellationToken)
        {
            var doacao = await _doacaoRepository.ConsultarIdAsync(request.ID);
            
            doacao.Deletar();

            await _doacaoRepository.DeletarAsync(doacao);

            return Unit.Value;
        }
    }
}
