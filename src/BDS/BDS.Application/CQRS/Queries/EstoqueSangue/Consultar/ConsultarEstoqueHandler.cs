using BDS.Application.DTOs;
using BDS.Core.Repositories;
using MediatR;

namespace BDS.Application.CQRS.Queries.EstoqueSangue.ConsultarId
{
    public class ConsultarEstoqueHandler : IRequestHandler<ConsultarEstoque, IList<EstoqueViewModel>>
    {
        private readonly IEstoqueRepository _repository;


        public ConsultarEstoqueHandler(IEstoqueRepository repository)
        {
            _repository = repository;
        }


        public async Task<IList<EstoqueViewModel>> Handle(ConsultarEstoque request, CancellationToken cancellationToken)
        {
            var estoque = await _repository.ConsultarEstoque();

            if (estoque is null)
                return null;

            var estoqueViewModel = estoque
                .Select(e => new EstoqueViewModel(e.TipoSanquineo, e.FatorRh, e.QuantidadeML, e.DataInclusao))
                .ToList();

            return estoqueViewModel;
        }
    }
}
