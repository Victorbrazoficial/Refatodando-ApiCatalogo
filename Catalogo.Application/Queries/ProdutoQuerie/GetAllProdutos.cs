using Catalogo.Application.ViewModels;
using MediatR;

namespace Catalogo.Application.Queries.ProdutoQuerie
{
    public class GetAllProdutos : IRequest<List<ProdutoViewModel>>
    {
        public string Query { get; set; }
    }
}
