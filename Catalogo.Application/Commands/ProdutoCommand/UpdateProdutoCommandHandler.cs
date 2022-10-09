using Catalogo.Core.Repositories;
using MediatR;

namespace Catalogo.Application.Commands.ProdutoCommand
{
    public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand, Unit>
    {
        private readonly IProdutoRepository _produtoRepository;

        public UpdateProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Unit> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByIdDetalhesAsync(request.Id);

            if (produto is null)
                throw new NullReferenceException($"A referencia {produto} é nula");

            produto.Update(request.Nome, request.Descricao, request.Preco, request.ImagemUrl, request.CategoriaId);

            await _produtoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
