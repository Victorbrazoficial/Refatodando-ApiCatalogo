using Catalogo.Application.ViewModels;
using Catalogo.Core.Repositories;
using MediatR;

namespace Catalogo.Application.Queries.CategoriaQuerie
{
    public class GetByIdDetalhesCategoriaHandler : IRequestHandler<GetByIdDetalhesCategoria, DetalhesCategoriaIdViewModel>
    {
        public ICategoriaRepository _categoriaRepository;

        public GetByIdDetalhesCategoriaHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<DetalhesCategoriaIdViewModel> Handle(GetByIdDetalhesCategoria request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdDetalhesAsync(request.Id);

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
