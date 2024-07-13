using BDS.Core.Entities;
using BDS.Core.Enums;

namespace BDS.Core.Repositories
{
    public interface IEstoqueRepository
    {
        Task<int> Incluir(Estoque estoque);
        Task<Estoque> ConsultarTipoSanguineo(FatorRh fator, TipoSanguineo tipo);
        Task<IList<Estoque>> ConsultarEstoque();
        Task<Estoque> ConsultarEstoqueId(Guid id);
        Task<int> AtualizarEstoque(Estoque estoque);
        Task<int> BaixarEstoque(Estoque estoque);
    }
}
