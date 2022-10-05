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

        public async Task<List<Categoria>> GetAllCategoriasProdutosAsync()
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

        public async Task Cadastrar(Categoria novaCategoria)
        {
            await _catalogoDbContext.Categorias.AddAsync(novaCategoria);
            await _catalogoDbContext.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var categoria = await _catalogoDbContext.Categorias.SingleOrDefaultAsync(c => c.CategoriaId == id);

            _catalogoDbContext.Categorias.Remove(categoria);
        }

        public async Task SaveChangeAsync()
        {
            await _catalogoDbContext.SaveChangesAsync();
        }
    }
}
