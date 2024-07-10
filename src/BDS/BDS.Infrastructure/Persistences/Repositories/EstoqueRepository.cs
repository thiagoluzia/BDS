using BDS.Core.Entities;
using BDS.Core.Enums;
using BDS.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BDS.Infrastructure.Persistences.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly DBContext _context;


        public EstoqueRepository(DBContext context)
        {
            _context = context;
        }


        public async  Task<int> AtualizarEstoque(Estoque estoque)
        {
            var estoqueAtual = await ConsultarTipoSanguineo(estoque.FatorRh, estoque.TipoSanquineo);

            if (estoqueAtual is null)
            {
                return await  Incluir(estoque);
            }               


            estoqueAtual.AtualizarEstoque(estoque.QuantidadeML);

            _context.Entry(estoqueAtual).State = EntityState.Modified;

            return await _context.SaveChangesAsync();

        }

        public async Task<int> BaixarEstoque(Estoque estoque)
        {
            var estoqueAtual = await ConsultarTipoSanguineo(estoque.FatorRh, estoque.TipoSanquineo);

            if (estoqueAtual is null)
                return default(int);
            

            estoqueAtual.BaixarEstoque(estoque.QuantidadeML);

            _context.Entry(estoqueAtual).State = EntityState.Modified;

            return await _context.SaveChangesAsync();

        }

        public async Task<IList<Estoque>> ConsultarEstoque()
        {
            var estoque = await _context.Estoques.ToListAsync();

            return estoque;
        }

        public async Task<Estoque> ConsultarEstoqueId(Guid id)
        {
            var estoque = await _context.Estoques.FindAsync(id);

            if (estoque is null)
                return null;

            return estoque;
        }

        public async Task<Estoque> ConsultarTipoSanguineo(FatorRh fator, TipoSanguineo tipo)
        {
            var doacoes = await  _context.Estoques.SingleOrDefaultAsync(f => f.FatorRh == fator && f.TipoSanquineo == tipo);

            if (doacoes is null)
                return null;

            return doacoes;
           
        }

        public async Task<int> Incluir(Estoque estoque)
        {
            var id = await _context.Estoques.AddAsync(estoque);

            return await _context.SaveChangesAsync();
        }
    }
}
