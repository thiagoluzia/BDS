using BDS.Core.Entities.Enums;

namespace BDS.Core.Entities
{
    public class Estoque : BaseEntity
    {
        public Estoque(TipoSanquineo tipoSanquineo, FatorRh fatorRh, int quantidadeMl)
        {
            TipoSanquineo = tipoSanquineo;
            FatorRh = fatorRh;
            QuantidadeML = quantidadeMl;
        }

        public TipoSanquineo TipoSanquineo { get; private set; }
        public FatorRh FatorRh { get; private set; }
        public int QuantidadeML { get; private set; }
        public EstoqueConfig EstoqueMinimo { get; private set; }

        public void AtualizarEstoque(TipoSanquineo tipoSanquineo, FatorRh fatorRh, int quantidadeMl)
        {
            TipoSanquineo = tipoSanquineo;
            FatorRh = fatorRh;
            QuantidadeML += quantidadeMl;
        }
    }
}
