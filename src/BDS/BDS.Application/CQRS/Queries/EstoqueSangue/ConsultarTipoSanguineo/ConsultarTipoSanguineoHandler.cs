using BDS.Application.DTOs;
using BDS.Core.Repositories;
using MediatR;

namespace BDS.Application.CQRS.Queries.EstoqueSangue.ConsultarTipoSanguineo
{
    public class ConsultarTipoSanguineoHandler : IRequestHandler<ConsultarTipoSanguineo, EstoqueViewModel>
    {

        private readonly IEstoqueRepository _repository;


        public ConsultarTipoSanguineoHandler(IEstoqueRepository repository)
        {
            _repository = repository;
        }


        public async  Task<EstoqueViewModel> Handle(ConsultarTipoSanguineo request, CancellationToken cancellationToken)
        {
            var estoqueTipo = await _repository.ConsultarTipoSanguineo(request.FatorRh, request.TipoSanquineo);

            if (estoqueTipo is null)
                return null;

            var estoqueViewModel = new EstoqueViewModel(estoqueTipo.TipoSanquineo
                                                       , estoqueTipo.FatorRh
                                                       , estoqueTipo.QuantidadeML
                                                       , estoqueTipo.DataInclusao);



            return estoqueViewModel;
        }
    }
}
