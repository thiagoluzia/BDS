﻿using BDS.Core.Entities;

namespace BDS.Core.Repositories
{
    public interface IDoadorRepository
    {
        Task<int> IncluirAsync(Doador entity);
        Task<int> AlterarAsync(Doador entity);
        Task<int> DeletarAsyncId(Guid id);
        Task<IEnumerable<Doador>> ConsultarAsync();
        Task<Doador> ConsultarIdAsync(Guid Id);
        Task<bool> ConsultarEmail(string Email);
    }
}
