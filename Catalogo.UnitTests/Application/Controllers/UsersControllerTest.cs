using Catalogo.API.Controllers;
using Catalogo.Application.Commands.LoginUserCommand;
using Catalogo.Application.Commands.UserCommand;
using Catalogo.Application.Queries.UserQuerie;
using Catalogo.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;

namespace Catalogo.UnitTests.Application.Controllers
{
    public class UsersControllerTest
    {
        private Mock<IMediator> _iMediator = new Mock<IMediator>();

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

        [Fact]
        public async Task Login_Executado_Retorna_200()
        {
            //Arranger
            //mock.Setup(x => x.Send<Tipo resultado>(It.IsAny<TipoInput>(), default)).ReturnsAsync(objeto esperado)
            _iMediator.Setup(x => x.Send<LoginUserViewModel>(It.IsAny<LoginUserCommand>(), default)).ReturnsAsync(new LoginUserViewModel());
            var loginUserCommand = new LoginUserCommand() { Email = "xxx@teste.com", Password = "123456789" };
            var controller = new UsersController(_iMediator.Object);

            //Act
            var result = await controller.Login(loginUserCommand);

            //Assert
            Assert.Equal(200, (result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async Task GetByIdUser_Executado_Retorna_200()
        {
            //Assert
            _iMediator.Setup(x => x.Send<DetalhesUserViewModel>(It.IsAny<GetByIdUser>(), default)).ReturnsAsync(new DetalhesUserViewModel());
            var getByIdUser = new GetByIdUser() { Id = 1 };
            var controller = new UsersController(_iMediator.Object);

            //Act
            var result = await controller.GetByIdUser(getByIdUser.Id);

            //Assert
            Assert.Equal(200, (result as OkObjectResult).StatusCode);
        }
    }
}
