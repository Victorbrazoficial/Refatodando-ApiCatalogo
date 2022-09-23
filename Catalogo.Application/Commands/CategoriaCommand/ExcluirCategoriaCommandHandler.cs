using Catalogo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Application.Commands.CategoriaCommand
{
    public class ExcluirCategoriaCommandHandler : IRequestHandler<ExcluirCategoriaCommand, Unit>
    {

        private readonly CatalogoDbContext _catalogoDbContext;

        public ExcluirCategoriaCommandHandler(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

        public async Task<Unit> Handle(ExcluirCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _catalogoDbContext.Categorias.SingleOrDefaultAsync(x => x.CategoriaId == request.Id);

            _catalogoDbContext.Categorias.Remove(categoria);

            await _catalogoDbContext.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}
