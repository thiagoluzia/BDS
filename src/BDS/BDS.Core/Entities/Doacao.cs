using BDS.Core.Enums;

namespace BDS.Core.Entities
{
    public class Doacao : BaseEntity
    {
        public Guid DoadorId { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeML { get; private set; }


        protected Doacao() { }

        public Doacao(Guid doadorId, DateTime dataDoacao, int quantidadeML)
        {
            DoadorId = doadorId;
            DataDoacao = dataDoacao;
            QuantidadeML = quantidadeML;
            
        }

        public void Atualizar(int quantidadeML)
        {
            QuantidadeML = +quantidadeML;
        }

        public bool Elegibilidade()
        {
            if(QuantidadePermitida())
                return true;

            return false;
        }

      
        protected bool QuantidadePermitida()
        {
            if(QuantidadeML >= (int)ELegibilidade.QUANTIDADE_ML_MINIMA && QuantidadeML <= (int)ELegibilidade.QUANTIDADE_ML_MAXIMA)
                return true;

            return false;
        }

    }
}
