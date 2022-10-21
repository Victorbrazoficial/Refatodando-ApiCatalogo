using Catalogo.Application.Queries.ProdutoQuerie;
using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Moq;

namespace Catalogo.UnitTests.Application.Queries.ProdutoQueries
{
    public class GetAllProdutosHandlerTest
    {
        [Fact]
        public async Task DoisProdutos_executado_RetornaDoisProdutos()
        {
            //Assert
            var produtos = ListaDeProdutos();
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var getAllProdutos = new GetAllProdutos();
            produtoRepositoryMock.Setup(p => p.GetAllAsync(getAllProdutos.Query).Result).Returns(produtos);
            var getAllProdutosHandler = new GetAllProdutosHandler(produtoRepositoryMock.Object);

            //Act
            var produtoResponse = await getAllProdutosHandler.Handle(getAllProdutos, new CancellationToken());

            //Assert
            Assert.NotNull(produtoResponse);
            Assert.NotEmpty(produtoResponse);
            Assert.Equal(produtos.Count, produtoResponse.Count);

            produtoRepositoryMock.Verify(p => p.GetAllAsync(getAllProdutos.Query), Times.Once());
        }

        private List<Produto> ListaDeProdutos()
        {
            var produtos = new List<Produto>()
            {
                new Produto()
                {
                    ProdutoId = 1,
                    Nome = "Teste Nome 1",
                    Preco = 10,
                    Descricao = "Teste descrição 1",
                    ImagemUrl = "teste1.jpg",
                    Estoque = 10,
                    DataCadastro = DateTime.Now,
                    CategoriaId = 1
                },
                new Produto()
                {
                    ProdutoId = 2,
                    Nome = "Teste Nome 2",
                    Preco = 20,
                    Descricao = "Teste descrição 2",
                    ImagemUrl = "teste2.jpg",
                    Estoque = 20,
                    DataCadastro = DateTime.Now,
                    CategoriaId = 2
                }
            };

            return produtos;
        }
    }
}
