using Catalogo.Application.ViewModels;
using MediatR;

namespace Catalogo.Application.Queries.ProdutoQuerie
{
    public class GetByIdDetalhesProduto : IRequest<DetalhesProdutoIdViewModel>
    {
        public int Id { get; set; }
    }
}
