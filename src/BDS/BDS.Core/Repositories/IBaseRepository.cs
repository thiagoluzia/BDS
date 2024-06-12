namespace BDS.Core.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<int> Incluir(T  entity);
        Task<int> Alterar(T entity);
        Task<int> Deletar(T entity);
        Task<IEnumerable<T>> Consultar();
        Task<T> ConsultarId(Guid Id);
    }
}
