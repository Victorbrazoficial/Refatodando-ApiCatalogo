using Catalogo.Application.ViewModels;
using MediatR;

namespace Catalogo.Application.Queries.CategoriaQuerie
{
    public class GetAllCategorias : IRequest<List<CategoriaViewModel>>
    {
        public string Query { get; set; }
    }
}
