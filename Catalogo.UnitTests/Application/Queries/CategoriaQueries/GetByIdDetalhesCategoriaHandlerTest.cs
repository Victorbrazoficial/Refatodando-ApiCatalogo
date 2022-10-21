using Catalogo.Application.Queries.CategoriaQuerie;
using Catalogo.Application.ViewModels;
using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Moq;

namespace Catalogo.UnitTests.Application.Queries
{
    public class GetByIdDetalhesCategoriaHandlerTest
    {
        [Fact]
        public async Task getByIdDetalhesCategoriaHandler_QuandoExecutado_RetornarUmDetalhesCategoriaIdViewModel()
        {
            //Arranger     
            var categoriaRepositoryMock = new Mock<ICategoriaRepository>();
            var getByIdDetalhesCategoria = new GetByIdDetalhesCategoria() { Id = 2 };
            categoriaRepositoryMock.Setup(c => c.GetByIdDetalhesAsync(getByIdDetalhesCategoria.Id).Result).Returns(new Categoria()
            {
                CategoriaId = 2,
                Nome = "Teste nome 2",
                ImagemUrl = "teste2.jpg",
                Produtos = new List<Produto>()
            });
            var getByIdDetalhesCategoriaHandler = new GetByIdDetalhesCategoriaHandler(categoriaRepositoryMock.Object);
            var experado = new DetalhesCategoriaIdViewModel()
            {
                Id = 2,
                Nome = "Teste nome 2",
                ImagemUrl = "teste2.jpg",
                Produtos = new List<Produto>()
            };

            //Act
            var categoriaViewModel = await getByIdDetalhesCategoriaHandler.Handle(getByIdDetalhesCategoria, new CancellationToken());

            //Assert
            Assert.NotNull(categoriaViewModel);
            Assert.Equal(experado.Nome, categoriaViewModel.Nome);
            Assert.Equal(experado.Id, categoriaViewModel.Id);
            Assert.Equal(experado.ImagemUrl, categoriaViewModel.ImagemUrl);
            Assert.Equal(experado.Produtos, categoriaViewModel.Produtos);

            categoriaRepositoryMock.Verify(c => c.GetByIdDetalhesAsync(getByIdDetalhesCategoria.Id).Result, Times.Once);
        }
    }
}
