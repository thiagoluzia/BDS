namespace BDS.Core.Entities
{
    public class Doacao : BaseEntity
    {
        public int DoadorID { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeML { get; private set; }
        public Doador? Doador { get; private set; }


        public Doacao(int doadorID, DateTime dataDoacao, int quantidadeML)
        {
            DoadorID = doadorID;
            DataDoacao = dataDoacao;
            QuantidadeML = +quantidadeML;
        }

        public void AtualizarDoacao(int quantidadeML)
        {
            QuantidadeML = +quantidadeML;
        }

    }
}
