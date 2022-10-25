using Catalogo.API.Controllers;
using Catalogo.Application.Commands.UserCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Catalogo.UnitTests.Application.Controllers
{
    public class UsersControllerTest
    {
        private readonly Mock<IMediator> _iMediator = new Mock<IMediator>(); 
        [Fact]
        public async Task Cadastrar_Executado_Retorna201()
        {
            var controller = new UsersController(_iMediator.Object);
            var cadastrarUserCommand =  new CadastrarUserCommand()
            {
                Id = 1,
                NomeCompleto = "Usuario 1",
                Email = "usuario1@teste.com",
                Password = "123456789",
                DataAniversario = DateTime.Now,
            };
            var result = await controller.Cadastrar(cadastrarUserCommand);

            Assert.NotNull(result);
            Assert.Equal(201, (result as CreatedAtActionResult).StatusCode);
        }
    }
}
