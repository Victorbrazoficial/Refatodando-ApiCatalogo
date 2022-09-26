using Catalogo.Application.ViewModels;
using Catalogo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Application.Queries.CategoriaQuerie
{
    public class GetAllCategoriasProdutosHandler : IRequestHandler<GetAllCategoriasProdutos, List<DetalhesCategoriaIdViewModel>>
    {
        public CatalogoDbContext _catalogoDbContext;

        public GetAllCategoriasProdutosHandler(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

        public async Task<List<DetalhesCategoriaIdViewModel>> Handle(GetAllCategoriasProdutos request, CancellationToken cancellationToken)
        {
            var categorias = _catalogoDbContext.Categorias;

            var categoriaViewModel = await categorias
                .Include(p => p.Produtos)
                .Select(x => new DetalhesCategoriaIdViewModel() { Id = x.CategoriaId, Nome = x.Nome, ImagemUrl = x.ImagemUrl, Produtos = x.Produtos })
                .OrderBy(o => o.Id)
                .ToListAsync();

            return categoriaViewModel;
        }
    }
}
