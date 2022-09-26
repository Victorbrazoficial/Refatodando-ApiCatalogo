using Catalogo.Application.ViewModels;
using MediatR;

namespace Catalogo.Application.Queries.CategoriaQuerie
{
    public class GetByIdDetalhesCategoria : IRequest<DetalhesCategoriaIdViewModel>
    {
        public int Id { get; set; }
    }
}
