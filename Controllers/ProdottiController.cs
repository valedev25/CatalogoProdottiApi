using CatalogoProdottiApi.Domain.Entities;
using CatalogoProdottiApi.Domain.Interfaces;
using CatalogoProdottiApi.Dtos;
using CatalogoProdottiApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoProdottiApi.Controllers
{
    [ApiController]
    [Route("api/prodotti")]
    public class ProdottiController : Controller
    {
        private readonly IProdottoService _service;

        public ProdottiController(IProdottoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Restituisce tutti i prodotti disponibili.
        /// </summary>      
        [HttpGet]
        public async Task<List<ProdottoResponseDto>> GetAllProdotti()
        {
            var prodotti = await _service.GetAllProdottiAsync();
            return prodotti.Select(p => new ProdottoResponseDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Prezzo = p.Prezzo,
                Categoria = p.Categoria
            }).ToList();
        }

        /// <summary>
        /// Restituisce il prodotto con l'id passato
        /// </summary>   
        [HttpGet("{id}")]
        public async Task<ProdottoResponseDto> GetProdotto(Guid id)
        {
            var p = await _service.GetProdottoByIdAsync(id);
            return new ProdottoResponseDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Prezzo = p.Prezzo,
                Categoria = p.Categoria
            };
        }

        /// <summary>
        /// Aggiunge un nuovo prodotto.
        /// </summary>   
        [HttpPost]
        public async Task<ActionResult<ProdottoResponseDto>> AddProdotto(ProdottoCUDto dto)
        {
            var p = await _service.AddProdottoAsync(dto.Nome, dto.Prezzo, dto.Categoria);
            var response = new ProdottoResponseDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Prezzo = p.Prezzo,
                Categoria = p.Categoria
            };
            return CreatedAtAction(nameof(GetProdotto), new { id = p.Id }, response);
        }


        /// <summary>
        /// Modifica il prodotto per id
        /// </summary>   
        [HttpPut("{id}")]
        public async Task<ProdottoResponseDto> UpdateProdotto(Guid id, ProdottoCUDto dto)
        {
            var p = await _service.UpdateProdottoAsync(id, dto.Nome, dto.Prezzo, dto.Categoria);
            return new ProdottoResponseDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Prezzo = p.Prezzo,
                Categoria = p.Categoria
            };
        }


        /// <summary>
        /// Elimina il prodotto per id
        /// </summary>   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdotto(Guid id)
        {
            await _service.DeleteProdottoAsync(id);
            return NoContent();
        }
    }
}
