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

        public async Task<List<Categoria>> GetAll(string query)
        {
            return await _catalogoDbContext.Categorias.ToListAsync();
        }
    }
}
