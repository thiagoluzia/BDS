﻿using BDS.Core.Entities;
using BDS.Core.Repositories;

namespace BDS.Infrastructure.Persistences.Repositories
{
    public class DoadorRepository : IDoadorRepository
    {
        public Task<int> AlterarAsync(Doador entity)
        {
            throw new NotImplementedException();
        }

        public async  Task<IEnumerable<Doador>> ConsultarAsync()
        {
            return new List<Doador>() { };
        }

        public Task<bool> ConsultarEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<Doador> ConsultarIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeletarAsyncId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncluirAsync(Doador entity)
        {
            throw new NotImplementedException();
        }
    }
}
