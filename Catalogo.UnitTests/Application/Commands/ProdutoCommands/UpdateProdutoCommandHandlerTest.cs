using Catalogo.Application.Commands.ProdutoCommand;
using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Moq;

namespace Catalogo.UnitTests.Application.Commands.ProdutoCommands
{
    public class UpdateProdutoCommandHandlerTest
    {
        [Fact]
        public async Task EntrouDados_Executado_RetornarSucesso()
        {
            //Arranger
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var updateProdutoCommand = new UpdateProdutoCommand();
            produtoRepositoryMock.Setup(p => p.GetByIdDetalhesAsync(updateProdutoCommand.Id).Result).Returns(new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste Nome 1",
                Preco = 10,
                Descricao = "Teste descrição 1",
                ImagemUrl = "teste1.jpg",
                CategoriaId = 1
            });
            var updateProdutoCommandHander = new UpdateProdutoCommandHandler(produtoRepositoryMock.Object);

            //Act
            await updateProdutoCommandHander.Handle(updateProdutoCommand, new CancellationToken());

            //Assert
            produtoRepositoryMock.Verify(p => p.GetByIdDetalhesAsync(It.IsAny<int>()), Times.Once);
            produtoRepositoryMock.Verify(p => p.SaveChangesAsync(), Times.Once);
        }
    }
}
