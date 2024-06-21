using MediatR;

namespace BDS.Application.CQRS.Commands.Doacoes.Deletar
{
    public  class DeletarDoacao : IRequest<Unit>
    {
        public Guid ID { get; private set; }


        public DeletarDoacao(Guid iD)
        {
            ID = iD;
        }

    }
}
