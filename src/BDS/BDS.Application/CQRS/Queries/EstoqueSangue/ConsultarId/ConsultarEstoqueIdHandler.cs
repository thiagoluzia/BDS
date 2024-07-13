using BDS.Application.DTOs;
using BDS.Core.Repositories;
using MediatR;

namespace BDS.Application.CQRS.Queries.EstoqueSangue.ConsultarId
{
    public class ConsultarEstoqueIdHandler : IRequestHandler<ConsultarEstoqueId, EstoqueViewModel>
    {

        private readonly IEstoqueRepository _repository;


        public ConsultarEstoqueIdHandler(IEstoqueRepository repository)
        {
            _repository = repository;

        }


        public async Task<EstoqueViewModel> Handle(ConsultarEstoqueId request, CancellationToken cancellationToken)
        {
            var estoque = await _repository.ConsultarEstoqueId(request.Id);

            if (estoque is null)
                return null;

            var estoqueViewModel = new EstoqueViewModel(estoque.TipoSanquineo
                                                        , estoque.FatorRh
                                                        , estoque.QuantidadeML
                                                        , estoque.DataInclusao);
            return estoqueViewModel;

        }
    }
}
