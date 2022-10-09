using Catalogo.Core.Repositories;
using Catalogo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Application.Commands.ProdutoCommand
{
    public class ExcluirProdutoCommandHandler : IRequestHandler<ExcluirProdutoCommand, Unit>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ExcluirProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Unit> Handle(ExcluirProdutoCommand request, CancellationToken cancellationToken)
        {
            await _produtoRepository.Excluir(request.Id);
            await _produtoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
