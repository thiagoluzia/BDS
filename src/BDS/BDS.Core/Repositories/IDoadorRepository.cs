using BDS.Core.Entities;

namespace BDS.Core.Repositories
{
    public interface IDoadorRepository
    {
        Task<int> IncluirAsync(Doador entity);
        Task<int> AlterarAsync(Doador entity);
        Task<int> DeletarAsyncT(int id);
        Task<IEnumerable<Doador>> ConsultarAsync();
        Task<Doador> ConsultarIdAsync(Guid Id);
    }
}
