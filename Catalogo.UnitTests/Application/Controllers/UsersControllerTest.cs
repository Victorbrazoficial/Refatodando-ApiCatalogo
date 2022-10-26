using Catalogo.API.Controllers;
using Catalogo.Application.Commands.LoginUserCommand;
using Catalogo.Application.Commands.UserCommand;
using Catalogo.Core.Entities;
using Catalogo.Core.Service;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Catalogo.UnitTests.Application.Controllers
{
    public class UsersControllerTest
    {
        private readonly Mock<IMediator> _iMediator = new Mock<IMediator>();
        private readonly Mock<IAuthService> _iAuthService = new Mock<IAuthService>();

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

        [Fact]
        public async Task Update_Executado_Retorna204()
        {
            var controller = new UsersController(_iMediator.Object);
            var updateUserCommand = new UpdateUserCommand()
            {
                Id = 1,
                NomeCompleto = "Usuario 1",
                Email = "usuario1@teste.com",
                Password = "123456789",
                DataAniversario = DateTime.Now,
            };
            var result = await controller.Update(updateUserCommand.Id, updateUserCommand);

            Assert.NotNull(result);
            Assert.Equal(204, (result as NoContentResult).StatusCode);
        }

        [Fact]
        public async Task GetAllUsers_Executado_Retorna_200()
        {
            //Arranger
            var controller = new UsersController(_iMediator.Object);

            //Act
            var result = await controller.GetAllUsers();

            //Assert
            Assert.Equal(200, (result as OkObjectResult).StatusCode);
        }

        private List<User> ListaDeUsuarios()
        {
            var usuarios = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    NomeCompleto = "Usuario 1",
                    Email = "usuario1@teste.com",
                    Password = "12345678",
                    DataAniversario = DateTime.Now,
                    DataCadastro = DateTime.Now
                },
                new User()
                {
                    Id = 2,
                    NomeCompleto = "Usuario 2",
                    Email = "usuario2@teste.com",
                    Password = "12345678",
                    DataAniversario = DateTime.Now,
                    DataCadastro = DateTime.Now
                },
                new User()
                {
                    Id = 3,
                    NomeCompleto = "Usuario 3",
                    Email = "usuario3@teste.com",
                    Password = "12345678",
                    DataAniversario = DateTime.Now,
                    DataCadastro = DateTime.Now
                }
            };

            return usuarios;
        }
    }
}
