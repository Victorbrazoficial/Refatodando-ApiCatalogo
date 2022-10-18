using Catalogo.Application.Queries.CategoriaQuerie;
using Catalogo.Application.ViewModels;
using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Moq;

namespace Catalogo.UnitTests.Application.Queries
{
    public class GetAllCategoriasHandlerTests
    {
        [Fact]
        public async Task ExistemTresCategorias_QuandoExecutado_RetornarTresCategoriaViewModel()
        {
            //A
            var categorias = new List<Categoria>()
            {
                new Categoria()
                {
                    CategoriaId = 1,
                    Nome = "Teste nome 1",
                    ImagemUrl = "teste1.jpg"
                },
                new Categoria()
                {
                    CategoriaId = 2,
                    Nome = "Teste nome 2",
                    ImagemUrl = "teste2.jpg",
                },
                new Categoria()
                {
                    CategoriaId = 3,
                    Nome = "Teste nome 3",
                    ImagemUrl = "teste3.jpg"
                }
            };
            var getAllCategoria = new GetAllCategorias();
            var categoriaRepositoryMock = new Mock<ICategoriaRepository>();
            categoriaRepositoryMock.Setup(c => c.GetAllAsync(getAllCategoria.Query).Result).Returns(categorias);
            var getAllCategoriaHandler = new GetAllCategoriasHandler(categoriaRepositoryMock.Object);

            //Act
            var categoriasViewModel = await getAllCategoriaHandler.Handle(getAllCategoria, new CancellationToken());

            //Assert
            Assert.NotNull(categoriasViewModel);
            Assert.NotEmpty(categoriasViewModel);
            Assert.Equal(categorias.Count, categoriasViewModel.Count);

            categoriaRepositoryMock.Verify(c => c.GetAllAsync(getAllCategoria.Query).Result, Times.Once);

        }
    }
}
