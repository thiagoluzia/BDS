using BDS.Core.Repositories;
using DTOs;
using MediatR;

namespace BDS.Application.CQRS.Queries.Doacoes.ConsultarId
{
    public class ConsultarDoacaoIdHandler : IRequestHandler<ConsultarDoacaoId, DoacaoViewModel>
    {

        private readonly IDoacaoRepository _repository;


        public ConsultarDoacaoIdHandler(IDoacaoRepository repository)
        {
            _repository = repository;
        }


        public async  Task<DoacaoViewModel> Handle(ConsultarDoacaoId request, CancellationToken cancellationToken)
        {
            var doacao = await _repository.ConsultarIdAsync(request.Id);

            if (doacao is null) return default;

            var doacaoViewModel = new DoacaoViewModel(doacao.DoadorID, doacao.DataDoacao, doacao.QuantidadeML);

            return doacaoViewModel;
        }
    }
}
