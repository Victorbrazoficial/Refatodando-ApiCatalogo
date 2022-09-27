using Catalogo.Application.ViewModels;
using Catalogo.Core.Repositories;
using MediatR;

namespace Catalogo.Application.Queries.CategoriaQuerie
{
    public class GetAllCategoriasHandler : IRequestHandler<GetAllCategorias, List<CategoriaViewModel>>
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public GetAllCategoriasHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<List<CategoriaViewModel>> Handle(GetAllCategorias request, CancellationToken cancellationToken)
        {
            var categorias = await _categoriaRepository.GetAll(request.Query);

            var categoriasViewModel =  categorias
                .Select(x => new CategoriaViewModel() { Id = x.CategoriaId, Nome = x.Nome, ImagemUrl = x.ImagemUrl })
                .OrderBy(x => x.Nome)
                .ToList();

            return categoriasViewModel;
        }
    }
}
