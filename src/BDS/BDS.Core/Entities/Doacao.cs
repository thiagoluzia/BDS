namespace BDS.Core.Entities
{
    public class Doacao : BaseEntity
    {
        public Guid DoadorID { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeML { get; private set; }
        public Doador? Doador { get; private set; }


        public Doacao(Guid doadorID, DateTime dataDoacao, int quantidadeML)
        {
            DoadorID = doadorID;
            DataDoacao = dataDoacao;
            QuantidadeML = +quantidadeML;
        }

        public void Atualizar(int quantidadeML)
        {
            QuantidadeML = +quantidadeML;
        }

    }
}
