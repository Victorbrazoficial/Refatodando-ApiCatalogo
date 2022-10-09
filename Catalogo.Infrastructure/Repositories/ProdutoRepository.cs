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

        public async Task Cadastrar(Produto novoProduto)
        {
            await _catalogoDbContext.AddAsync(novoProduto);
        }

        public async Task<List<Produto>> GetAllAsync(string query)
        {
            var produtos = await _catalogoDbContext.Produtos.ToListAsync();
           
            return produtos;
        }

        public async Task<Produto> GetByIdDetalhesAsync(int id)
        {
            var produto = await _catalogoDbContext.Produtos.SingleOrDefaultAsync(p => p.ProdutoId == id);

            if (produto is null)
                return null;

            return produto;
        }

        public async Task SaveChangesAsync()
        {
            await _catalogoDbContext.SaveChangesAsync();
        }

    }
}
