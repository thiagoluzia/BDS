using DTOs;
using MediatR;

namespace BDS.Application.CQRS.Queries.Doadores.Consultar
{
    public  class ConsultarDoador : IRequest<IEnumerable<DoadorViewModel>>
    {

        public Guid Id { get; private set; }


        public ConsultarDoador(Guid id)
        {
            Id = id;
        }

    }
}
