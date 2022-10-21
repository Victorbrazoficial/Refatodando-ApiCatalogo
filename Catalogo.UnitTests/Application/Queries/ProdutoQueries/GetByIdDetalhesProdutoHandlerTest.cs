using Catalogo.Application.Queries.ProdutoQuerie;
using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Moq;

namespace Catalogo.UnitTests.Application.Queries.ProdutoQueries
{
    public class GetByIdDetalhesProdutoHandlerTest
    {
        [Fact]
        public async Task ListaDeProdutos_Executado_RetornaUmProdutoPorID()
        {
            //Assert
            var produtos = ListaDeProdutos();
            var produtoRepository = new Mock<IProdutoRepository>();
            var getByIdDetalhesProduto = new GetByIdDetalhesProduto();
            produtoRepository.Setup(p => p.GetByIdDetalhesAsync(getByIdDetalhesProduto.Id).Result).Returns(produtos[1]);
            var getByIdDetalhesProdutoHandler = new GetByIdDetalhesProdutoHandler(produtoRepository.Object);

            //Act
            var responseProduto = await getByIdDetalhesProdutoHandler.Handle(getByIdDetalhesProduto, new CancellationToken());

            //Assert
            Assert.NotNull(responseProduto);
            Assert.Equal(produtos[1].Nome, responseProduto.Nome);
            Assert.Equal(produtos[1].Descricao, responseProduto.Descricao);
            Assert.Equal(produtos[1].ImagemUrl, responseProduto.ImagemUrl);
            Assert.Equal(produtos[1].DataCadastro, responseProduto.DataCadastro);
            Assert.Equal(produtos[1].ProdutoId, responseProduto.ProdutoId);
            Assert.Equal(produtos[1].Preco, responseProduto.Preco);
            Assert.Equal(produtos[1].CategoriaId, responseProduto.CategoriaId);

            produtoRepository.Verify(p => p.GetByIdDetalhesAsync(getByIdDetalhesProduto.Id).Result, Times.Once());
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
