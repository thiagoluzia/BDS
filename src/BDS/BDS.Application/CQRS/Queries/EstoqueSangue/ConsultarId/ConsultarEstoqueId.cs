using BDS.Application.DTOs;
using MediatR;

namespace BDS.Application.CQRS.Queries.EstoqueSangue.ConsultarId
{
    public class ConsultarEstoqueId : IRequest<EstoqueViewModel>
    {
      
        public Guid Id { get; private set; }

        public ConsultarEstoqueId(Guid id)
        {
            Id = id;
        }
    }
}
