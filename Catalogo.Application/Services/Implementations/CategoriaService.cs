using Catalogo.Application.Services.Interfaces;
using Catalogo.Infrastructure.Persistence;

namespace Catalogo.Application.Services.Implementations
{
    public class CategoriaService : ICategoriaService
    {
        private readonly CatalogoDbContext _catalogoDbContext;

        public CategoriaService(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }
    }
}
