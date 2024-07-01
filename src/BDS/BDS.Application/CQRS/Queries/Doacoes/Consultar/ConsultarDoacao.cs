using DTOs;
using MediatR;

namespace BDS.Application.CQRS.Queries.Doacoes.Consultar
{
    public class ConsultarDoacao : IRequest<IEnumerable<DoacaoViewModel>>
    {

        public Guid Id { get; private set; }


        public ConsultarDoacao()
        {
        }

    }
}
