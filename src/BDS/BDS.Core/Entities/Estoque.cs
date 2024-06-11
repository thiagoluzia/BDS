using BDS.Core.Enums;

namespace BDS.Core.Entities
{
    public class Estoque : BaseEntity
    {
        public TipoSanquineo TipoSanquineo { get; private set; }
        public FatorRh FatorRh { get; private set; }
        public int QuantidadeML { get; private set; }


        public Estoque(TipoSanquineo tipoSanquineo, FatorRh fatorRh, int quantidadeMl)
        {
            TipoSanquineo = tipoSanquineo;
            FatorRh = fatorRh;
            QuantidadeML = quantidadeMl;
        }


        public void AtualizarEstoque(int quantidadeMl)
        {
            QuantidadeML += quantidadeMl;
        }
    }
}
