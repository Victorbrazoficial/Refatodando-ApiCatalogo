using Catalogo.Application.InputModels;
using Catalogo.Application.Services.Interfaces;
using Catalogo.Application.ViewModels;
using Catalogo.Core.Entities;
using Catalogo.Infrastructure.Persistence;

namespace Catalogo.Application.Services.Implementations
{
    public class ProdutoService : IProdutoService
    {
        private readonly CatalogoDbContext _catalogoDbContext;

        public ProdutoService(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

    }
}