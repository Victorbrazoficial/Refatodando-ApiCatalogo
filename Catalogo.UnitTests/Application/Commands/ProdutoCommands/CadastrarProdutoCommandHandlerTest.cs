using Catalogo.Application.Commands.ProdutoCommand;
using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Moq;

namespace Catalogo.UnitTests.Application.Commands.ProdutoCommands
{
    public class CadastrarProdutoCommandHandlerTest
    {
        [Fact]
        public async Task entrouDados_Executado_RetornarIdDoProduto()
        {
            //Arranger
            var produtoRepository = new Mock<IProdutoRepository>();
            var cadastraProdutoCommand = new CadastrarProdutoCommand()
            {
                Nome = "Teste Nome 1",
                Preco = 10,
                Descricao = "Teste descrição 1",
                ImagemUrl = "teste1.jpg",
                DataCadastro = DateTime.Now,
                CategoriaId = 1
            };
            var cadastrarProdutoCommandHandler = new CadastrarProdutoCommandHandler(produtoRepository.Object);

            //Act
            var id = await cadastrarProdutoCommandHandler.Handle(cadastraProdutoCommand, new CancellationToken());

            //Assert
            Assert.True(id >= 0);
            Assert.True(cadastraProdutoCommand.ProdutoId == id);

            produtoRepository.Verify(p => p.Cadastrar(It.IsAny<Produto>()), Times.Once);
        }
    }
}
