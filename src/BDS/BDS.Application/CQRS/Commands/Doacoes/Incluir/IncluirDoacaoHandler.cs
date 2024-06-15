using BDS.Core.Entities;
using BDS.Core.Repositories;
using MediatR;

namespace BDS.Application.CQRS.Commands.Doacoes.Incluir
{
    public class IncluirDoacaoHandler : IRequestHandler<IncluirDoacao, Guid>
    {
        private readonly IDoacaoRepository _repository;


        public IncluirDoacaoHandler(IDoacaoRepository repository)
        {
            _repository = repository;
        }


        public async Task<Guid> Handle(IncluirDoacao request, CancellationToken cancellationToken)
        {
            var doacao = new Doacao(request.DoadorID, request.DataDoacao,request.QuantidadeML);

            await _repository.IncluirAsync(doacao);

            return doacao.Id;
        }
    }
}
