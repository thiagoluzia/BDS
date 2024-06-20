using BDS.Core.Entities;

namespace DTOs
{
    public class DoacaoViewModel
    {
     
        public Guid DoadorID { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeML { get; private set; }


        public DoacaoViewModel(Guid doadorID, DateTime dataDoacao, int quantidadeML)
        {
            DoadorID = doadorID;
            DataDoacao = dataDoacao;
            QuantidadeML = quantidadeML;
        }

    }
}