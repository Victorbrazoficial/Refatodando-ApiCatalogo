using Catalogo.Application.ViewModels;
using MediatR;

namespace Catalogo.Application.Queries.CategoriaQuerie
{
    public class GetAllCategoriasProdutos : IRequest<List<DetalhesCategoriaIdViewModel>>
    {
    }
}
