using BDS.Core.Entities;
using BDS.Core.Repositories;

namespace BDS.Infrastructure.Persistences.Repositories
{
    public class DoacaoRepository : IDoacaoRepository
    {
        public Task<int> AlterarAsync(Doacao entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Doacao>> ConsultarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Doacao> ConsultarIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeletarAsyncId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncluirAsync(Doacao entity)
        {
            throw new NotImplementedException();
        }
    }
}
