using DTOs;
using MediatR;

namespace BDS.Application.CQRS.Queries.Doadores.ConsultarId
{
    public class ConsultarDoadorId : IRequest<DoadorViewModel>
    {

        public Guid Id { get; private set; }


        public ConsultarDoadorId(Guid id)
        {
            Id = id;
        }

    }
}
