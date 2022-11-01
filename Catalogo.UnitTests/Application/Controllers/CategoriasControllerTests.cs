using Catalogo.API.Controllers;
using Catalogo.Application.Commands.CategoriaCommand;
using Catalogo.Application.Commands.UserCommand;
using Catalogo.Application.Queries.CategoriaQuerie;
using Catalogo.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Catalogo.UnitTests.Application.Controllers
{
    public class CategoriasControllerTests
    {
        private Mock<IMediator> _iMediator = new Mock<IMediator>();

        [Fact]
        public async Task GetCategorias_Executado_200()
        {
            //Arranger
            var controller = new CategoriasController(_iMediator.Object);
            var request = "";

            //Act
            var result = await controller.GetCategorias(request);

            //Assert
            Assert.Equal(200, (result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async Task GetCategoriasProdutos_Executado_Retorna200()
        {
            //Arranger
            var controller = new CategoriasController(_iMediator.Object);

            //Act
            var result = await controller.GetCategoriasProdutos();

            //Assert
            Assert.Equal(200, (result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async Task GetById_Executado_Retornar200()
        {
            //Arranger
            _iMediator.Setup(x => x.Send<DetalhesCategoriaIdViewModel>(It.IsAny<GetByIdDetalhesCategoria>(), default)).ReturnsAsync(new DetalhesCategoriaIdViewModel());
            var controller = new CategoriasController(_iMediator.Object);

            //Act
            var result = await controller.GetById(1);

            //Assert.
            Assert.Equal(200, (result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async Task Cadastrar_Executado_Retorna201()
        {
            //Arranger
            var controller = new CategoriasController(_iMediator.Object);
            var request = new CadastrarCategoriaCommand();

            //Act
            var result = await controller.Cadastrar(request);

            //Assert
            Assert.Equal(201, (result as CreatedAtActionResult).StatusCode);
        }

        [Fact]
        public async Task Update_Executado_Renorta204()
        {
            //Arranger
            var controller = new CategoriasController(_iMediator.Object);
            var updateUserCommand = new UpdateCategoriaCommand();
            
            //Act
            var result = await controller.Update(updateUserCommand.Id, updateUserCommand);

            //Assert
            Assert.Equal(204, (result as NoContentResult).StatusCode);
        }

        [Fact]
        public async Task Delete_Executado_Renorta204()
        {
            //Arranger
            var controller = new CategoriasController(_iMediator.Object);
            var excluirCategoriacommand = new ExcluirCategoriaCommand() { Id = 1 };

            //Act
            var result = await controller.Delete(excluirCategoriacommand.Id);

            //Assert
            Assert.Equal(204, (result as NoContentResult).StatusCode);

        }
    }
}
