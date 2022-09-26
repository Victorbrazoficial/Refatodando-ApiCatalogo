using Catalogo.Application.ViewModels;
using Catalogo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Application.Queries.CategoriaQuerie
{
    public class GetAllCategoriasHandler : IRequestHandler<GetAllCategorias, List<CategoriaViewModel>>
    {
        private readonly CatalogoDbContext _catalogoDbContext;

        public GetAllCategoriasHandler(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

        public async Task<List<CategoriaViewModel>> Handle(GetAllCategorias request, CancellationToken cancellationToken)
        {
            var categorias = _catalogoDbContext.Categorias;
            var categoriasViewModel = await categorias
                .Select(x => new CategoriaViewModel() { Id = x.CategoriaId, Nome = x.Nome, ImagemUrl = x.ImagemUrl })
                .OrderBy(x => x.Nome)
                .ToListAsync();

            return categoriasViewModel;
        }
    }
}
