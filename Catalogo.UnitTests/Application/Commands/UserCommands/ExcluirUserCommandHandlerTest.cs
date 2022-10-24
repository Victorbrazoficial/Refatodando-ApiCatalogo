using Catalogo.Application.Commands.UserCommand;
using Catalogo.Core.Repositories;
using Moq;

namespace Catalogo.UnitTests.Application.Commands.UserCommands
{
    public class ExcluirUserCommandHandlerTest
    {
        [Fact]
        public async Task ExcluirUser_Executado_VerificaSeOMetodoFoiChamado()
        {
            //Arranger
            var userRepository = new Mock<IUserRepository>();
            var excluirUserCommand = new ExcluirUserCommand();
            var excluirUserCommandHandler = new ExcluirUserCommandHandler(userRepository.Object);

            //Act
            await excluirUserCommandHandler.Handle(excluirUserCommand, new CancellationToken());

            //Assert
            userRepository.Verify(u => u.Excluir(It.IsAny<int>()), Times.Once());
        }
    }
}
