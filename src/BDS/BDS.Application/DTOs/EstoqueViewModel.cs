using BDS.Core.Enums;

namespace BDS.Application.DTOs
{
    public class EstoqueViewModel
    {

        public TipoSanguineo TipoSanquineo { get; private set; }
        public FatorRh FatorRh { get; private set; }
        public int QuantidadeML { get; private set; }
        public DateTime DataInclusao { get; private set; }

        public EstoqueViewModel(TipoSanguineo tipoSanquineo, FatorRh fatorRh, int quantidadeML, DateTime dataInclusao)
        {
            TipoSanquineo = tipoSanquineo;
            FatorRh = fatorRh;
            QuantidadeML = quantidadeML;
            DataInclusao = dataInclusao;
        }
    }
}
