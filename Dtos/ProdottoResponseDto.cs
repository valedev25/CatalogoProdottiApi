namespace CatalogoProdottiApi.Dtos
{
    public class ProdottoResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Prezzo { get; set; }
        public string Categoria { get; set; } = string.Empty;
    }
}
