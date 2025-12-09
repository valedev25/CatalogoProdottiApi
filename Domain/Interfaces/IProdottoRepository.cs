using CatalogoProdottiApi.Domain.Entities;

namespace CatalogoProdottiApi.Domain.Interfaces
{
    public interface IProdottoRepository
    {
        Task<Prodotto?> GetByIdAsync(Guid id);
        Task<List<Prodotto>> GetAllAsync();
        Task AddAsync(Prodotto prodotto);
        Task UpdateAsync(Prodotto prodotto);
        Task DeleteAsync(Guid id);
    }
}
