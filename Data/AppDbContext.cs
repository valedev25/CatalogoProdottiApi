using CatalogoProdottiApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CatalogoProdottiApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Prodotto> Prodotti => Set<Prodotto>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
