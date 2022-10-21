using Catalogo.Application.Commands.CategoriaCommand;
using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Moq;

namespace Catalogo.UnitTests.Application.Commands.CategoriaCommands
{
    public class UpdateCategoriaCommandHandlerTest
    {
        [Fact]
        public async Task EntrouDados_Executado_RetornarSucesso()
        {
            //Arranger
            var categoriaRepositoryMock = new Mock<ICategoriaRepository>();
            var updateCategoriaCommand = new UpdateCategoriaCommand();
            categoriaRepositoryMock.Setup(c => c.GetByIdDetalhesAsync(updateCategoriaCommand.Id).Result).Returns(new Categoria()
            {
                CategoriaId = 2,
                Nome = "Teste nome 2",
                ImagemUrl = "teste2.jpg",
                Produtos = new List<Produto>()
            });
            var updateCategoriaCommandHandler = new UpdateCategoriaCommandHandler(categoriaRepositoryMock.Object);

            //Act
            await updateCategoriaCommandHandler.Handle(updateCategoriaCommand, new CancellationToken());

            //Assert
            categoriaRepositoryMock.Verify(c => c.GetByIdDetalhesAsync(It.IsAny<int>()), Times.Once());
            categoriaRepositoryMock.Verify(c => c.SaveChangeAsync(), Times.Once());
        }
    }
}
