

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
           
            return new Prodotto(nome, prezzo, categoria);
        }

        public void Update(string nome, decimal prezzo, string categoria)
        {
           
            Nome = nome;
            Prezzo = prezzo;
            Categoria = categoria;
        }



    }
}
