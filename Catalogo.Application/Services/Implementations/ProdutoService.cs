using Catalogo.Application.InputModels;
using Catalogo.Application.Services.Interfaces;
using Catalogo.Application.ViewModels;
using Catalogo.Core.Entities;
using Catalogo.Infrastructure.Persistence;

namespace Catalogo.Application.Services.Implementations
{
    public class ProdutoService : IProdutoService
    {
        private readonly CatalogoDbContext _catalogoDbContext;

        public ProdutoService(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

        public List<ProdutoViewModel> GetAll(string query)
        {
            var produtos = _catalogoDbContext.Produtos;
            var produtoViewModel = produtos
                .Select(x => new ProdutoViewModel() { Nome = x.Nome, Descricao = x.Descricao, Estoque = x.Estoque, ImagemUrl = x.ImagemUrl })
                .OrderBy(x => x.Nome)
                .ToList();

            return produtoViewModel;
        }

        public DetalhesProdutoIdViewModel GetById(int id)
        {
            var produto = _catalogoDbContext.Produtos.SingleOrDefault(p => p.ProdutoId == id);

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