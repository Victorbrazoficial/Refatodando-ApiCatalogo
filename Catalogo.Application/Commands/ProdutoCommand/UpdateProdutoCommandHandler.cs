using Catalogo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Application.Commands.ProdutoCommand
{
    public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand, Unit>
    {
        private readonly CatalogoDbContext _catalogoDbContext;

        public UpdateProdutoCommandHandler(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

        public async Task<Unit> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _catalogoDbContext.Produtos.SingleOrDefaultAsync(p => p.ProdutoId == request.Id);

            if (produto is null)
                throw new NullReferenceException($"A referencia {produto} é nula");

            produto.Update(request.Nome, request.Descricao, request.Preco, request.ImagemUrl, request.CategoriaId);

            await _catalogoDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
