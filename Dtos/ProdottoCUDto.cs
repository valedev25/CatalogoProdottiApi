using System.ComponentModel.DataAnnotations;

namespace CatalogoProdottiApi.Dtos
{
    public class ProdottoCUDto
    {        
        public string Nome { get; set; } = string.Empty;

        public decimal Prezzo { get; set; }
      
        public string Categoria { get; set; } = string.Empty;
    }
}
