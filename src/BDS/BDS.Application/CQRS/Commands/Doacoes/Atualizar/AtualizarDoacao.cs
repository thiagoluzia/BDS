using MediatR;

namespace BDS.Application.CQRS.Commands.Doacoes.Atualizar
{
    public class AtualizarDoacao : IRequest<Unit>
    {
        public Guid Id { get; private set; }
        public int QuantidadeML { get; private set; }


        public AtualizarDoacao(int quantidadeML)
        {
            QuantidadeML += quantidadeML;
        }
    }
}
