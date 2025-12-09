namespace CatalogoProdottiApi.Exceptions
{
    public class ProdottoExceptions : Exception
    {
        public enum ErrorType
        {
            NotFound,
            Invalid,
            Unknown,
            AlreadyExists
        }
        public ErrorType Type { get; }

        private ProdottoExceptions(string message, ErrorType type) : base(message)
        {
            Type = type;
        }


        // errori di validazione personalizzati
        public static ProdottoExceptions Invalid(string message) =>
            new ProdottoExceptions(message, ErrorType.Invalid);

        // errori generici
        public static ProdottoExceptions UnknownError(string message) =>
            new ProdottoExceptions(message, ErrorType.Unknown);

        // prodotto non trovato
        public static ProdottoExceptions NotFound(Guid id) =>
            new ProdottoExceptions($"Prodotto con ID {id} non trovato.", ErrorType.NotFound);

        public static ProdottoExceptions AlreadyExists(string nome, string categoria) =>
            new ProdottoExceptions($"Il prodotto '{nome}' nella categoria '{categoria}' esiste già.", ErrorType.AlreadyExists);
    }

}
