using Catalogo.Application.Commands.UserCommand;
using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Catalogo.Core.Service;
using Moq;

namespace Catalogo.UnitTests.Application.Commands.UserCommands
{
    public class CadastrarUserCommandHandlerTest
    {
        [Fact]
        public async Task entrouDados_Executado_RetornarIdDoUser()
        {
            var userRepository = new Mock<IUserRepository>();
            var authService = new Mock<IAuthService>();
            var cadastrarUserCommand = new CadastrarUserCommand()
            {

                Id = 1,
                NomeCompleto = "Usuario 1",
                Email = "usuario1@teste.com",
                Password = "123456789",
                DataAniversario = DateTime.Now,
            };
            var cadastrarUserCommandHandler = new CadastrarUserCommandHandler(userRepository.Object, authService.Object);

            //Act
            var id = await cadastrarUserCommandHandler.Handle(cadastrarUserCommand, new CancellationToken());

            //Assert
            Assert.True(id >= 0);

            userRepository.Verify(u => u.CadastrarAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
