using BDS.Core.Entities;
using BDS.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BDS.Infrastructure.Persistences.Repositories
{
    public class DoacaoRepository : IDoacaoRepository
    {
        private readonly DBContext _dbContext;


        public DoacaoRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<int> AlterarAsync(Doacao entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doacao>> ConsultarAsync()
        {
            return await _dbContext.Doacoes.ToListAsync();
        }

        public async Task<Doacao?> ConsultarIdAsync(Guid Id)
        {
            return await _dbContext.Doacoes.SingleOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<int> DeletarAsync(Doacao entity)
        {

            _dbContext.Entry(entity).State = EntityState.Modified;

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Guid> IncluirAsync(Doacao entity)
        {
            await _dbContext.Doacoes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;

        }
    }
}
