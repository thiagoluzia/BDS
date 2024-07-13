using BDS.Core.Repositories;
using MediatR;

namespace BDS.Application.CQRS.Commands.EstoqueSangue.Baixar
{
    public class BaixarEstoqueHandler : IRequestHandler<BaixarEstoque, Unit>
    {
        private readonly IEstoqueRepository _repository;


        public BaixarEstoqueHandler(IEstoqueRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(BaixarEstoque request, CancellationToken cancellationToken)
        {
            var estoque = await _repository.ConsultarEstoqueId(request.Id);

            if(estoque is null)
                return default(Unit);


            var id = await _repository.BaixarEstoque(estoque = new BDS.Core.Entities.Estoque(request.Tipo, request.FatorRh, request.QuantidadeML));

            if (id == 0)
                return default(Unit);

            return Unit.Value;
        }
    }
}
