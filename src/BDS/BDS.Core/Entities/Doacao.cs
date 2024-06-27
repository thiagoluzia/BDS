namespace BDS.Core.Entities
{
    public class Doacao : BaseEntity
    {
        public Guid DoadorId { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeML { get; private set; }
        public Doador? Doador { get; private set; }


        public Doacao(Guid doadorId, DateTime dataDoacao, int quantidadeML)
        {
            DoadorId = doadorId;
            DataDoacao = dataDoacao;
            QuantidadeML = +quantidadeML;
        }

        public void Atualizar(int quantidadeML)
        {
            QuantidadeML = +quantidadeML;
        }

    }
}
