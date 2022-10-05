using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Catalogo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly CatalogoDbContext _catalogoDbContext;
        public CategoriaRepository(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

        public async Task<List<Categoria>> GetAllAsync(string query)
        {
            return await _catalogoDbContext.Categorias.ToListAsync();
        }

        public async Task<List<Categoria>> GetAllCategoriasProdutos()
        {
            return await _catalogoDbContext.Categorias.Include(p => p.Produtos).ToListAsync();
        }

        public async Task<Categoria> GetByIdDetalhesAsync(int id)
        {
            var categoria = await _catalogoDbContext.Categorias.SingleOrDefaultAsync(x => x.CategoriaId == id);

            if (categoria is null)
                return null;

            return categoria;
        }
    }
}
