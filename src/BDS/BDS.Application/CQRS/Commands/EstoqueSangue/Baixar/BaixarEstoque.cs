using BDS.Application.DTOs;
using BDS.Core.Enums;
using MediatR;

namespace BDS.Application.CQRS.Commands.EstoqueSangue.Baixar
{
    public class BaixarEstoque : IRequest<Unit>
    {
     
        public Guid Id { get; private set; }
        public TipoSanguineo Tipo { get; private set; }
        public FatorRh FatorRh { get; private set; }
        public int QuantidadeML { get; private set; }


        public BaixarEstoque(Guid id, TipoSanguineo tipo, FatorRh fatorRh, int quantidadeML)
        {
            Id = id;
            Tipo = tipo;
            FatorRh = fatorRh;
            QuantidadeML = quantidadeML;
        }

    }
}
