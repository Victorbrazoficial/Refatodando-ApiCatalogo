using Catalogo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Application.Commands.ProdutoCommand
{
    public class ExcluirProdutoCommandHandler : IRequestHandler<ExcluirProdutoCommand, Unit>
    {
        private readonly CatalogoDbContext _catalogoDbContext;

        public ExcluirProdutoCommandHandler(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

        public async Task<Unit> Handle(ExcluirProdutoCommand request, CancellationToken cancellationToken)
        {

            var produto = await _catalogoDbContext.Produtos.SingleOrDefaultAsync(p => p.ProdutoId == request.Id);

             _catalogoDbContext.Produtos.Remove(produto);

            await _catalogoDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
