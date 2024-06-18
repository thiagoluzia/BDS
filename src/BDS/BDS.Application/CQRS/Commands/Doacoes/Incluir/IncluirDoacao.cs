using MediatR;

namespace BDS.Application.CQRS.Commands.Doacoes.Incluir
{
    public class IncluirDoacao : IRequest<Guid>
    {

        public int DoadorID { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeML { get; private set; }


        public IncluirDoacao(int doadorID, DateTime dataDoacao, int quantidadeML)
        {
            DoadorID = doadorID;
            QuantidadeML = quantidadeML;

            DataDoacao = DateTime.Now;
        }

    }
}
