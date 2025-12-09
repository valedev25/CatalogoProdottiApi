

using CatalogoProdottiApi.Exceptions;

namespace CatalogoProdottiApi.Domain.Entities
{
    public class Prodotto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; } = null!;
        public decimal Prezzo { get; private set; }
        public string Categoria { get; private set; } = null!;

        private Prodotto() { }

        private Prodotto(string nome, decimal prezzo, string categoria)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Prezzo = prezzo;
            Categoria = categoria;
        }

        public static Prodotto Create(string nome, decimal prezzo, string categoria)
        {
            Validate(nome, prezzo, categoria);
            return new Prodotto(nome, prezzo, categoria);
        }

        public void Update(string nome, decimal prezzo, string categoria)
        {
            Validate(nome, prezzo, categoria);
            Nome = nome;
            Prezzo = prezzo;
            Categoria = categoria;
        }

        private static void Validate(string nome, decimal prezzo, string categoria)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw ProdottoExceptions.Invalid("Nome non può essere vuoto.");

            if (prezzo < 0)
                throw ProdottoExceptions.Invalid("Prezzo non può essere negativo.");

            if (string.IsNullOrWhiteSpace(categoria))
                throw ProdottoExceptions.Invalid("Categoria non può essere vuota.");
        }




    }
}
