using Catalogo.API.Controllers;
using Catalogo.Application.Commands.ProdutoCommand;
using Catalogo.Application.Commands.UserCommand;
using Catalogo.Application.Queries.ProdutoQuerie;
using Catalogo.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Catalogo.UnitTests.Application.Controllers
{
    public class ProdutosControllerTest
    {
        private Mock<IMediator> _iMediator = new Mock<IMediator>();

        [Fact]
        public async Task GetProdutos_Executado_Retorna200()
        {
            //Arranger
            var controller = new ProdutosController(_iMediator.Object);

            //Act
            var result = await controller.GetProdutos("");

            //Assert
            Assert.Equal(200, (result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async Task GetById_Executado_Retorna200()
        {
            //Arranger
            var controller = new ProdutosController(_iMediator.Object);
            _iMediator.Setup(x => x.Send<DetalhesProdutoIdViewModel>(It.IsAny<GetByIdDetalhesProduto>(), default)).ReturnsAsync(new DetalhesProdutoIdViewModel());

            //Act
            var result = await controller.GetById(1);

            //Assert
            Assert.Equal(200, (result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async Task Cadastrar_Executado_Retorna201()
        {
            //Arranger
            var controller = new ProdutosController(_iMediator.Object);

            //Act
            var result = await controller.Cadastrar(new CadastrarProdutoCommand());

            //Assert
            Assert.Equal(201, (result as CreatedAtActionResult).StatusCode);
        }

        [Fact]
        public async Task Update_Executado_Retorna204()
        {
            //Arranger
            var controller = new ProdutosController(_iMediator.Object);
            var updateProdutosCommand = new UpdateProdutoCommand()
            {
                Id = 1
            };

            //act
            var result = await controller.Update(updateProdutosCommand.Id, updateProdutosCommand);

            //Assert
            Assert.Equal(204, (result as NoContentResult).StatusCode);
        }

        [Fact]
        public async Task Delete_Executado_Retorna204()
        {
            var controller = new ProdutosController(_iMediator.Object);

            //act
            var result = await controller.Delete(1);

            //Arranger
            Assert.Equal(204, (result as NoContentResult).StatusCode);
        }
    }
}
