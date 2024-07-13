using BDS.Core.Enums;

namespace BDS.Core.Entities
{
    public class EstoqueConfig : BaseEntity
    {

        public int QuatidadeMinima { get; private set; }
        public TipoSanguineo TipoSanquineo { get; private set; }
        public FatorRh FatorRh { get; private set; }


        protected EstoqueConfig() { }

        public void AtualizarQuantidadeMinima(int quatidadeMinima, TipoSanguineo tipoSanquineo, FatorRh fatorRh)
        {
            QuatidadeMinima = quatidadeMinima;
            TipoSanquineo = tipoSanquineo;
            FatorRh = fatorRh;
        }

    }
}
