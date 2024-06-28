using BDS.Core.Entities;
using BDS.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BDS.Infrastructure.Persistences.Repositories
{
    public class DoadorRepository : IDoadorRepository
    {
        private readonly DBContext _dbContext;

        public DoadorRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AlterarAsync(Doador entity)
        {

            var doador = await _dbContext.Doadores
                                    .AsNoTracking()
                                    .SingleOrDefaultAsync(x => x.Id == entity.Id);

            if(doador is null)
                return default(int);

           await  _dbContext.Doadores.AddAsync( doador = new Doador(entity.Nome
                                                        , entity.Email
                                                        , entity.DataNascimento
                                                        , entity.Genero
                                                        , entity.Peso
                                                        , entity.TipoSanquineo
                                                        , entity.Fator
                                                        , entity.Endereco));

            return await  _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Doador>> ConsultarAsync()
        {

            var doadores = await _dbContext.Doadores.AsNoTracking().ToListAsync();

            if (doadores is null)
                return Enumerable.Empty<Doador>();

            return doadores;

        }

        public async Task<bool> ConsultarEmail(string Email)
        {

            var existe = await _dbContext.Doadores.SingleOrDefaultAsync(e => e.Email == Email);

            return existe == null;

        }

        public async Task<Doador> ConsultarIdAsync(Guid Id)
        {

            var doador = await _dbContext.Doadores
                .SingleOrDefaultAsync(x => x.Id == Id);

            if (doador is null)
                return default;

            return doador;

        }

        public async Task<int> DeletarAsyncId(Guid id)
        {

            var doador = await _dbContext.Doadores.SingleOrDefaultAsync(x => x.Id == id);

            if (doador is not null)
                _dbContext.Doadores.Remove(doador);

            return _dbContext.SaveChanges();

        }

        public async Task<int> IncluirAsync(Doador entity)
        {

            var doadorId = await _dbContext.Doadores.AddAsync(entity);

            return await _dbContext.SaveChangesAsync();

        }
    }
}
