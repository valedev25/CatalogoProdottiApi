using CatalogoProdottiApi.Exceptions;
using System.Text.Json;

namespace CatalogoProdottiApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ProdottoExceptions ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex.Type switch
                {
                    ProdottoExceptions.ErrorType.NotFound => StatusCodes.Status404NotFound,
                    ProdottoExceptions.ErrorType.Invalid => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError
                };

                await context.Response.WriteAsJsonAsync(new { errore = ex.Message });
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new { errore = ex.Message });
            }
        }
    }
}
