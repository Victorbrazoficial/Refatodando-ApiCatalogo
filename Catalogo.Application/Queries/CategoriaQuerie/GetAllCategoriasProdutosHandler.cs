using Catalogo.Application.ViewModels;
using Catalogo.Core.Repositories;
using MediatR;

namespace Catalogo.Application.Queries.CategoriaQuerie
{
    public class GetAllCategoriasProdutosHandler : IRequestHandler<GetAllCategoriasProdutos, List<DetalhesCategoriaIdViewModel>>
    {
        public ICategoriaRepository _categoriaRepository;

        public GetAllCategoriasProdutosHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<List<DetalhesCategoriaIdViewModel>> Handle(GetAllCategoriasProdutos request, CancellationToken cancellationToken)
        {
            var categorias = await _categoriaRepository.GetAllCategoriasProdutos();

            var categoriaViewModel = categorias
                .Select(x => new DetalhesCategoriaIdViewModel() { Id = x.CategoriaId, Nome = x.Nome, ImagemUrl = x.ImagemUrl, Produtos = x.Produtos })
                .OrderBy(o => o.Id)
                .ToList();

            return categoriaViewModel;
        }
    }
}
