namespace BDS.Core.Repositories
{
    public interface IDoadorServiceRepository
    {
        Task<bool> ExisteEmail(string email);
    }
}
