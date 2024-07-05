using BDS.Core.Entities;

namespace BDS.Core.Repositories
{
    public interface IDoacaoRepository 
    {
        Task<Guid> IncluirAsync(Doacao entity);
        Task<int> AlterarAsync(Doacao entity);
        Task<int> DeletarAsync(Doacao entity);
        Task<IEnumerable<Doacao>> ConsultarAsync();
        Task<Doacao?> ConsultarIdAsync(Guid Id);
    }
}
