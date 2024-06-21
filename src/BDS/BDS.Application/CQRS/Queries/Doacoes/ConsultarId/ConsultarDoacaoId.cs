using DTOs;
using MediatR;

namespace BDS.Application.CQRS.Queries.Doacoes.ConsultarId
{
    public class ConsultarDoacaoId : IRequest<DoacaoViewModel>
    {

        public Guid Id { get; private set; }


        public ConsultarDoacaoId(Guid id)
        {
            Id = id;
        }

    }
}
