using BDS.Core.Entities;

namespace BDS.Core.Repositories
{
    public interface IDoacaoRepository 
    {
        Task<int> IncluirAsync(Doacao entity);
        Task<int> AlterarAsync(Doacao entity);
        Task<int> DeletarAsyncT(int id);
        Task<IEnumerable<Doacao>> ConsultarAsync();
        Task<Doacao> ConsultarIdAsync(Guid Id);
    }
}
