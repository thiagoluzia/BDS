using BDS.Core.Enums;
using MediatR;

namespace BDS.Application.CQRS.Commands.Estoque.Incluir
{
    public class IncluirEstoque : IRequest<Guid>
    {

        public TipoSanguineo TipoSanquineo { get; private set; }
        public FatorRh FatorRh { get; private set; }
        public int QuantidadeML { get; private set; }


        public IncluirEstoque(TipoSanguineo tipoSanquineo, FatorRh fatorRh, int quantidadeML)
        {
            TipoSanquineo = tipoSanquineo;
            FatorRh = fatorRh;
            QuantidadeML = quantidadeML;
        }
    }
}
