using Catalogo.Application.ViewModels;
using Catalogo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Application.Queries.CategoriaQuerie
{
    public class GetByIdDetalhesCategoriaHandler : IRequestHandler<GetByIdDetalhesCategoria, DetalhesCategoriaIdViewModel>
    {
        public CatalogoDbContext _catalogoDbContext;

        public GetByIdDetalhesCategoriaHandler(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

        public async Task<DetalhesCategoriaIdViewModel> Handle(GetByIdDetalhesCategoria request, CancellationToken cancellationToken)
        {
            var categoria = await _catalogoDbContext.Categorias.SingleOrDefaultAsync(x => x.CategoriaId == request.Id);

            if (categoria is null)
                return null;

            var detalhesViewModel = new DetalhesCategoriaIdViewModel()
            {
                Nome = categoria.Nome,
                ImagemUrl = categoria.ImagemUrl,
                Id = categoria.CategoriaId,
                Produtos = categoria.Produtos
            };

            return detalhesViewModel;
        }
    }
}
