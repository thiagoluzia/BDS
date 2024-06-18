using BDS.Core.Entities;

namespace DTOs
{
    public class DoacaoViewModel
    {
     
        public int DoadorID { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeML { get; private set; }


        public DoacaoViewModel(int doadorID, DateTime dataDoacao, int quantidadeML)
        {
            DoadorID = doadorID;
            DataDoacao = dataDoacao;
            QuantidadeML = quantidadeML;
        }

    }
}