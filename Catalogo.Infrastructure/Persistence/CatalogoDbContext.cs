using Catalogo.Core.Entities;

namespace Catalogo.Infrastructure.Persistence
{
    public class CatalogoDbContext
    {
        public List<Categoria> Categorias { get; set; }
        public List<Produto> Produtos { get; set; }

        public CatalogoDbContext()
        {
            Categorias = new List<Categoria>
            {
                new Categoria(){CategoriaId = 1, Nome = "Bebidas", ImagemUrl = "bebidas.jpg"},
                new Categoria(){CategoriaId = 2, Nome = "Lanche", ImagemUrl = "lanches.jpg"}
            };

            Produtos = new List<Produto>()
            {
                new Produto(){ProdutoId = 1, Nome = "Coca-Cola", ImagemUrl = "cocacola.jpg", Descricao = "Cocaloca 1L", DataCadastro = DateTime.Now, Preco = 5, Estoque = 10, Categoria = Categorias[0]},
                new Produto(){ProdutoId = 2, Nome = "Água", ImagemUrl = "agua.jpg", Descricao = "Água 1L", DataCadastro = DateTime.Now, Preco = 4, Estoque = 20, Categoria = Categorias[0]},
                new Produto(){ProdutoId = 3, Nome = "Pão", ImagemUrl = "pao.jpg", Descricao = "Pão frances", DataCadastro = DateTime.Now, Preco = 0.50m, Estoque = 50, Categoria = Categorias[1]}
            };
        }
    }
}
