using Catalogo.Core.Entities;
using Catalogo.Infrastructure.Persistence;
using MediatR;

namespace Catalogo.Application.Commands.ProdutoCommand
{
    public class CadastrarProdutoCommandHandler : IRequestHandler<CadastrarProdutoCommand, int>
    {
        private readonly CatalogoDbContext _catalogoDbContext;

        public CadastrarProdutoCommandHandler(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

        public async Task<int> Handle(CadastrarProdutoCommand request, CancellationToken cancellationToken)
        {
            var novoProduto = new Produto()
            {
                ProdutoId = request.ProdutoId,
                Nome = request.Nome,
                Preco = request.Preco,
                Descricao = request.Descricao,
                ImagemUrl = request.ImagemUrl,
                DataCadastro = request.DataCadastro,
                CategoriaId = request.CategoriaId
            };

            await _catalogoDbContext.Produtos.AddAsync(novoProduto);

            await _catalogoDbContext.SaveChangesAsync();

            return novoProduto.ProdutoId;
        }
    }
}
