using Catalogo.Application.ViewModels;
using Catalogo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Application.Queries.ProdutoQuerie
{
    public class GetByIdDetalhesProdutoHandler : IRequestHandler<GetByIdDetalhesProduto, DetalhesProdutoIdViewModel>
    {
        public CatalogoDbContext _catalogoDbContext;

        public GetByIdDetalhesProdutoHandler(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

        public async Task<DetalhesProdutoIdViewModel> Handle(GetByIdDetalhesProduto request, CancellationToken cancellationToken)
        {
            var produto = await _catalogoDbContext.Produtos.SingleOrDefaultAsync(p => p.ProdutoId == request.Id);

            if (produto is null)
                return null;

            var detalhesProdutoId = new DetalhesProdutoIdViewModel()
            {
                ProdutoId = produto.ProdutoId,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Descricao = produto.Descricao,
                ImagemUrl = produto.ImagemUrl,
                Estoque = produto.Estoque,
                DataCadastro = produto.DataCadastro,
                CategoriaId = produto.CategoriaId
            };

            return detalhesProdutoId;
        }
    }
}
