using CatalogoProdottiApi.Domain.Entities;
using CatalogoProdottiApi.Domain.Interfaces;
using CatalogoProdottiApi.Exceptions;

namespace CatalogoProdottiApi.Services
{

    public class ProdottoService : IProdottoService
    {
        private readonly IProdottoRepository _repo;

        public ProdottoService(IProdottoRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Prodotto>> GetAllProdottiAsync() =>
           _repo.GetAllAsync();

        public async Task<Prodotto> GetProdottoByIdAsync(Guid id) =>
            await _repo.GetByIdAsync(id)
            ?? throw ProdottoExceptions.NotFound(id);

        public async Task<Prodotto> AddProdottoAsync(string nome, decimal prezzo, string categoria)
        {
            //controllo se il prodotto è già esistente
            await CheckProdottoExistsAsync(nome, categoria);

            var prodotto = Prodotto.Create(nome, prezzo, categoria);
            await _repo.AddAsync(prodotto);
            return prodotto;
        }

        public async Task<Prodotto> UpdateProdottoAsync(Guid id, string nome, decimal prezzo, string categoria)
        {
            var prodotto = await _repo.GetByIdAsync(id)
                ?? throw ProdottoExceptions.NotFound(id);

            //controllo se il prodotto è già esistente
            await CheckProdottoExistsAsync(nome, categoria);

            prodotto.Update(nome, prezzo, categoria);
            await _repo.UpdateAsync(prodotto);
            return prodotto;
        }

        public async Task DeleteProdottoAsync(Guid id)
        {
            var prodotto = await _repo.GetByIdAsync(id)
                ?? throw ProdottoExceptions.NotFound(id);

            await _repo.DeleteAsync(id);
        }

        private async Task CheckProdottoExistsAsync(string nome, string categoria)
        {
            var prodottiEsistenti = await _repo.GetAllAsync();

            if (prodottiEsistenti.Any(p =>  p.Nome.Equals(nome) &&
                    p.Categoria.Equals(categoria)))
            {
                throw ProdottoExceptions.AlreadyExists(nome, categoria);
            }
        }
    }
}
