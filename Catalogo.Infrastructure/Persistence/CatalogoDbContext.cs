using Catalogo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Catalogo.Infrastructure.Persistence
{
    public class CatalogoDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
