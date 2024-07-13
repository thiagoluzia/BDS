using BDS.Application.DTOs;
using BDS.Core.Enums;
using MediatR;

namespace BDS.Application.CQRS.Queries.EstoqueSangue.ConsultarTipoSanguineo
{
    public class ConsultarTipoSanguineo : IRequest<EstoqueViewModel>
    {
     
        public TipoSanguineo TipoSanquineo { get; private set; }
        public FatorRh FatorRh { get; private set; }


        public ConsultarTipoSanguineo(TipoSanguineo tipoSanquineo, FatorRh fatorRh)
        {
            TipoSanquineo = tipoSanquineo;
            FatorRh = fatorRh;
        }
    }
}
