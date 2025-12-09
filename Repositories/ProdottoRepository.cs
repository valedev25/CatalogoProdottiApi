using CatalogoProdottiApi.Data;
using CatalogoProdottiApi.Domain.Entities;
using CatalogoProdottiApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProdottiApi.Repositories
{
    public class ProdottoRepository : IProdottoRepository
    {
        private readonly AppDbContext _context;

        public ProdottoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Prodotto?> GetByIdAsync(Guid id) =>
          _context.Prodotti.FirstOrDefaultAsync(p => p.Id == id);

        public Task<List<Prodotto>> GetAllAsync() =>
            _context.Prodotti.ToListAsync();

        public async Task AddAsync(Prodotto prodotto)
        {
            await _context.Prodotti.AddAsync(prodotto);
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateAsync(Prodotto prodotto)
        {
            _context.Prodotti.Update(prodotto);
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(Guid id)
        {
            var prodotto = await GetByIdAsync(id);
            if (prodotto != null)
            {
                _context.Prodotti.Remove(prodotto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
