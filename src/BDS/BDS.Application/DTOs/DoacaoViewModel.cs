using BDS.Core.Entities;

namespace DTOs
{
    public class DoacaoViewModel
    {
     
        public  Guid Id { get; private set; }   
        public Guid DoadorID { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeML { get; private set; }


        public DoacaoViewModel(Guid id, Guid doadorID, DateTime dataDoacao, int quantidadeML)
        {
            Id = id;
            DoadorID = doadorID;
            DataDoacao = dataDoacao;
            QuantidadeML = quantidadeML;
        }

    }
}