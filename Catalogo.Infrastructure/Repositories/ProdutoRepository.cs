using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Catalogo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private CatalogoDbContext _catalogoDbContext;

        public ProdutoRepository(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

        public async Task<List<Produto>> GetAll(string query)
        {
            var produtos = await _catalogoDbContext.Produtos.ToListAsync();
           
            return produtos;
        }
    }
}
