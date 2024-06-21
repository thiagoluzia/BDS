using BDS.Core.Repositories;
using DTOs;
using MediatR;

namespace BDS.Application.CQRS.Queries.Doacoes.Consultar
{
    public class ConsultarDoacaoHandler : IRequestHandler<ConsultarDoacao, IEnumerable<DoacaoViewModel>>
    {

        private readonly IDoacaoRepository _repository;


        public ConsultarDoacaoHandler(IDoacaoRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<DoacaoViewModel>> Handle(ConsultarDoacao request, CancellationToken cancellationToken)
        {
            var doacoes = await _repository.ConsultarAsync();

            if (doacoes is null) return default;

            var doacoesViewModel = doacoes
                .Select(d => new DoacaoViewModel(d.DoadorID, d.DataDoacao, d.QuantidadeML))
                .ToList();

            return doacoesViewModel;
        }
    }
}
