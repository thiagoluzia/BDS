using BDS.Core.Enums;

namespace BDS.Core.Entities
{
    public class EstoqueConfig : BaseEntity
    {

        public int QuatidadeMinima { get; private set; }
        public TipoSanquineo TipoSanquineo { get; private set; }
        public FatorRh FatorRh { get; private set; }


        public void AtualizarQuantidadeMinima(int quatidadeMinima, TipoSanquineo tipoSanquineo, FatorRh fatorRh)
        {
            QuatidadeMinima = quatidadeMinima;
            TipoSanquineo = tipoSanquineo;
            FatorRh = fatorRh;
        }

    }
}
