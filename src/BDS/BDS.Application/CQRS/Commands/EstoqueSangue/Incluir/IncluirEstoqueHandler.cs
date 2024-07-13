using BDS.Application.CQRS.Commands.Estoque.Incluir;
using BDS.Core.Repositories;
using MediatR;

namespace BDS.Application.CQRS.Commands.EstoqueSangue.Incluir
{
    public class IncluirEstoqueHandler : IRequestHandler<IncluirEstoque, Guid>
    {
        private readonly IEstoqueRepository _repository;


        public IncluirEstoqueHandler(IEstoqueRepository repository)
        {
            _repository = repository;
        }


        public async Task<Guid> Handle(IncluirEstoque request, CancellationToken cancellationToken)
        {

            var estoque = new BDS.Core.Entities.Estoque(request.TipoSanquineo, request.FatorRh, request.QuantidadeML);
        
             await _repository.Incluir(estoque);

            return estoque.Id;

        }
    }
}
