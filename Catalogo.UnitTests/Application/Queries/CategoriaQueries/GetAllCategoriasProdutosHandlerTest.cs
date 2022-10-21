using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Moq;

namespace Catalogo.Application.Queries.CategoriaQuerie
{
    public class GetAllCategoriasProdutosHandlerTest
    {
        [Fact]
        public async Task GetAllCategoriasProdutosHandler_QuandoExecutado_RetornaCategoriasEProdutos()
        {
            //Arranger
            var categoriasProdutos = ListaDeCategoriasEProdutos();
            var categoriaRepositoryMock = new Mock<ICategoriaRepository>();
            categoriaRepositoryMock.Setup(c => c.GetAllCategoriasProdutosAsync().Result).Returns(categoriasProdutos);
            var getAllCategoriasProdutos = new GetAllCategoriasProdutos();
            var getAllCategoriasProdutosHandler = new GetAllCategoriasProdutosHandler(categoriaRepositoryMock.Object);

            var experado = new Categoria()
            {
                CategoriaId = 1,
                Nome = "Teste nome 1",
                ImagemUrl = "teste1.jpg",
                Produtos = new List<Produto>()
                        {
                            new Produto()
                            {
                                ProdutoId = 1,
                                Nome = "Teste Nome Produto 1",
                                Descricao = "Teste produto 1",
                                Estoque = 10,
                                ImagemUrl = "teste1.jpg",
                                Preco = 10.0m,
                                CategoriaId = 1,
                                DataCadastro = DateTime.Now,
                                Categoria = null
                            }
                        }
            };

            //Act
            var categoriasEProdutosViewModel = await getAllCategoriasProdutosHandler.Handle(getAllCategoriasProdutos, new CancellationToken());

            //Assert
            Assert.NotNull(categoriasEProdutosViewModel);
            Assert.NotEmpty(categoriasEProdutosViewModel);
            Assert.Equal(categoriasProdutos.Count, categoriasEProdutosViewModel.Count);

            Assert.Equal(experado.Nome, categoriasEProdutosViewModel[0].Nome);
            Assert.Equal(experado.CategoriaId, categoriasEProdutosViewModel[0].Id);
            Assert.Equal(experado.ImagemUrl, categoriasEProdutosViewModel[0].ImagemUrl);
            Assert.Equal(experado.Produtos.Count, categoriasEProdutosViewModel[0].Produtos.Count);

            categoriaRepositoryMock.Verify(c => c.GetAllCategoriasProdutosAsync().Result, Times.Once);
        }

        private List<Categoria> ListaDeCategoriasEProdutos()
        {
            var categoriasProdutos = new List<Categoria>()
                {
                    new Categoria()
                    {
                        CategoriaId = 1,
                        Nome = "Teste nome 1",
                        ImagemUrl = "teste1.jpg",
                        Produtos = new List<Produto>()
                        {
                            new Produto()
                            {
                                ProdutoId = 1,
                                Nome = "Teste Nome Produto 1",
                                Descricao = "Teste produto 1",
                                Estoque = 10,
                                ImagemUrl = "teste1.jpg",
                                Preco = 10.0m,
                                CategoriaId = 1,
                                DataCadastro = DateTime.Now,
                                Categoria = null
                            }
                        }
                    },
                    new Categoria()
                    {
                        CategoriaId = 2,
                        Nome = "Teste nome 2",
                        ImagemUrl = "teste2.jpg",
                        Produtos = new List<Produto>()
                        {
                            new Produto()
                            {
                                ProdutoId = 2,
                                Nome = "Teste Nome Produto 2",
                                Descricao = "Teste produto 2",
                                Estoque = 20,
                                ImagemUrl = "teste2.jpg",
                                Preco = 20.0m,
                                CategoriaId = 2,
                                DataCadastro = DateTime.Now,
                                Categoria = null
                            }
                        }
                    }
                };

            return categoriasProdutos;
        }
    }
}
