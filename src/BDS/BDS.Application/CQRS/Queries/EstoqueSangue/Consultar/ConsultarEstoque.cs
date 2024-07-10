using BDS.Application.DTOs;
using MediatR;

namespace BDS.Application.CQRS.Queries.EstoqueSangue.ConsultarId
{
    public  class ConsultarEstoque : IRequest<IList<EstoqueViewModel>>
    {
        public ConsultarEstoque() { }
    }
}
