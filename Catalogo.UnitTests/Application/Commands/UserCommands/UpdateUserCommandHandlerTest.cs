using Catalogo.Application.Commands.UserCommand;
using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Moq;

namespace Catalogo.UnitTests.Application.Commands.UserCommands
{
    public class UpdateUserCommandHandlerTest
    {
        [Fact]
        public async Task EntrouDados_Executado_AtualizaDados()
        {
            //Arranger
            var userRepository = new Mock <IUserRepository>();
            var updateUserCommand = new UpdateUserCommand();       
            userRepository.Setup(u => u.GetByIdAsync(updateUserCommand.Id).Result).Returns(new User()
            {
                NomeCompleto = "Usuario 1",
                Email = "usuario1@teste.com",
                Password = "123456789",
                DataAniversario = DateTime.Now,
            });
            var updateUserCommandHandler = new UpdateUserCommandHandler(userRepository.Object);

            //act
            await updateUserCommandHandler.Handle(updateUserCommand, new CancellationToken());

            //Assert
            userRepository.Verify(u => u.GetByIdAsync(It.IsAny<int>()), Times.Once());
            userRepository.Verify(u => u.SaveChangesAsync(),Times.Once());
        }
    }
}
