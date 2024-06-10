namespace BDS.Core.Entities
{
    public class Doacao : BaseEntity
    {
        public Doacao(int doadorID, DateTime dataDoacao, int quantidadeML)
        {
            DoadorID = doadorID;
            DataDoacao = dataDoacao;
            QuantidadeML = quantidadeML;
        }

        public int DoadorID { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeML { get; private set; }
        public Doador? Doador { get; private set; }

    }
}
