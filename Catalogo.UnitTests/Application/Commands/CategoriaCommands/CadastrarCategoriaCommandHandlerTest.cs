using Catalogo.Application.Commands.CategoriaCommand;
using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Moq;

namespace Catalogo.UnitTests.Application.Commands.CategoriaCommands
{
    public class CadastrarCategoriaCommandHandlerTest
    {
        [Fact]
        public async Task entrouDados_Executado_RetornarCategoriaId()
        {
            //Arranger
            var categoriaRepositoryMock = new Mock<ICategoriaRepository>();
            var cadastarCategoriaCommand = new CadastrarCategoriaCommand()
            {
                CategoriaId = 1,
                Nome = "Teste nome 1",
                ImagemUrl = "teste1.jpg"
            };

            var categoriaCadastroCommandHandler = new CadastrarCategoriaCommandHandler(categoriaRepositoryMock.Object);

            //Act
            var id = await categoriaCadastroCommandHandler.Handle(cadastarCategoriaCommand, new CancellationToken());

            //Assert
            Assert.True(id > 0);
            Assert.Equal(1, id);

            categoriaRepositoryMock.Verify(c => c.Cadastrar(It.IsAny<Categoria>()), Times.Once());
        }
    }
}
