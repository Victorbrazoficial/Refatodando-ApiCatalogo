using Catalogo.Application.ViewModels;
using Catalogo.Core.Repositories;
using MediatR;

namespace Catalogo.Application.Queries.ProdutoQuerie
{
    public class GetAllProdutosHandler : IRequestHandler<GetAllProdutos, List<ProdutoViewModel>>
    {
        public IProdutoRepository _produtoRepository;

        public GetAllProdutosHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<List<ProdutoViewModel>> Handle(GetAllProdutos request, CancellationToken cancellationToken)
        {
            var produtos = await _produtoRepository.GetAll(request.Query);

            var produtoViewModel =  produtos
                .Select(x => new ProdutoViewModel() { Id = x.ProdutoId, Nome = x.Nome, Descricao = x.Descricao, Estoque = x.Estoque, ImagemUrl = x.ImagemUrl })
                .OrderBy(x => x.Nome)
                .ToList();

            return produtoViewModel;
        }
    }
}
