using MediatR;

namespace BDS.Application.CQRS.Commands.Doadores.Deletar
{
    public  class DeletarDoador : IRequest<Unit>
    {

        public Guid Id { get; private set; }


        public DeletarDoador(Guid id)
        {
            Id = id;
        }

    }
}
