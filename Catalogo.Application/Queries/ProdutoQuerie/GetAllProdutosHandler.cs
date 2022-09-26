using Catalogo.Application.ViewModels;
using Catalogo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Application.Queries.ProdutoQuerie
{
    public class GetAllProdutosHandler : IRequestHandler<GetAllProdutos, List<ProdutoViewModel>>
    {
        public CatalogoDbContext _catalogoDbContext;

        public GetAllProdutosHandler(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

        public async Task<List<ProdutoViewModel>> Handle(GetAllProdutos request, CancellationToken cancellationToken)
        {
            var produtos = _catalogoDbContext.Produtos;
            var produtoViewModel = await produtos
                .Select(x => new ProdutoViewModel() { Id = x.ProdutoId, Nome = x.Nome, Descricao = x.Descricao, Estoque = x.Estoque, ImagemUrl = x.ImagemUrl })
                .OrderBy(x => x.Nome)
                .ToListAsync();

            return produtoViewModel;
        }
    }
}
