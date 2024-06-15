namespace BDS.Core.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<int> IncluirAsync(T  entity);
        Task<int> AlterarAsync(T entity);
        Task<int> DeletarAsync(T entity);
        Task<IEnumerable<T>> ConsultarAsync();
        Task<T> ConsultarIdAsync(Guid Id);
    }
}
