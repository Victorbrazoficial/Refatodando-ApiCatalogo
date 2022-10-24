using Catalogo.Application.Commands.ProdutoCommand;
using Catalogo.Core.Repositories;
using Moq;

namespace Catalogo.UnitTests.Application.Commands.ProdutoCommands
{
    public class ExcluirProdutoCommandHandlerTest
    {
        [Fact]
        public async Task ExcluirProduto_Executado_VerificaSeOMetodoFoiChamado()
        {
            //Arranger
            var produtoRepository = new Mock<IProdutoRepository>();
            var excluirProdutoCommand = new ExcluirProdutoCommand();
            var excluirProdutoCommandHandler = new ExcluirProdutoCommandHandler(produtoRepository.Object);

            //Act
            await excluirProdutoCommandHandler.Handle(excluirProdutoCommand, new CancellationToken());

            //Assert
            Assert.True(excluirProdutoCommand.Id >= 0);
            
            produtoRepository.Verify(p => p.Excluir(It.IsAny<int>()), Times.Once());
        }
    }
}
