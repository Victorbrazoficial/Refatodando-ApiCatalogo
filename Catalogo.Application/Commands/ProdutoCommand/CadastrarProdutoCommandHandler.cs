using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Catalogo.Infrastructure.Persistence;
using MediatR;

namespace Catalogo.Application.Commands.ProdutoCommand
{
    public class CadastrarProdutoCommandHandler : IRequestHandler<CadastrarProdutoCommand, int>
    {
        private readonly IProdutoRepository _produtoRepository;

        public CadastrarProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<int> Handle(CadastrarProdutoCommand request, CancellationToken cancellationToken)
        {
            var novoProduto = new Produto()
            {
                ProdutoId = request.ProdutoId,
                Nome = request.Nome,
                Preco = request.Preco,
                Descricao = request.Descricao,
                ImagemUrl = request.ImagemUrl,
                DataCadastro = request.DataCadastro,
                CategoriaId = request.CategoriaId
            };

            await _produtoRepository.Cadastrar(novoProduto);
            await _produtoRepository.SaveChangesAsync();

            return novoProduto.ProdutoId;
        }
    }
}
