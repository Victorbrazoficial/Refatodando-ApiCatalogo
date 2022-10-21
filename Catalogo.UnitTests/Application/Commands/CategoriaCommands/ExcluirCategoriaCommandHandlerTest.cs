using Catalogo.Application.Commands.CategoriaCommand;
using Catalogo.Core.Repositories;
using Moq;

namespace Catalogo.UnitTests.Application.Commands.CategoriaCommands
{
    public class ExcluirCategoriaCommandHandlerTest
    {
        [Fact]
        public async Task ExcluirConta_Executado_VerificaSeOMetodoFoiChamado()
        {
            //Arranger
            var categoriaRepositoryMock = new Mock<ICategoriaRepository>();
            var excluirCategoriaCommand = new ExcluirCategoriaCommand() { Id = 1 };
            var excluirCategoriaCommandHandle = new ExcluirCategoriaCommandHandler(categoriaRepositoryMock.Object);

            //Act
            await excluirCategoriaCommandHandle.Handle(excluirCategoriaCommand, new CancellationToken());

            //Assert 
            Assert.True(excluirCategoriaCommand.Id > 0);
            Assert.Equal(1, excluirCategoriaCommand.Id);
            categoriaRepositoryMock.Verify(c => c.Excluir(excluirCategoriaCommand.Id), Times.Once);
        }
    }
}
