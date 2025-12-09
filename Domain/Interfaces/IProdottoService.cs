using CatalogoProdottiApi.Domain.Entities;

namespace CatalogoProdottiApi.Domain.Interfaces
{
    public interface IProdottoService
    {
        Task<List<Prodotto>> GetAllProdottiAsync();
        Task<Prodotto> GetProdottoByIdAsync(Guid id);
        Task<Prodotto> AddProdottoAsync(string nome, decimal prezzo, string categoria);
        Task<Prodotto> UpdateProdottoAsync(Guid id, string nome, decimal prezzo, string categoria);
        Task DeleteProdottoAsync(Guid id);
    }
}
