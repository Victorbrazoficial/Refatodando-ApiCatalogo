using Catalogo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Application.Commands.CategoriaCommand
{
    public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand,Unit>
    {
        private readonly CatalogoDbContext _catalogoDbContext;

        public UpdateCategoriaCommandHandler(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

        public async Task<Unit> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _catalogoDbContext.Categorias.SingleOrDefaultAsync(x => x.CategoriaId == request.Id);

            categoria.Update(request.Nome, request.ImagemUrl);

            await _catalogoDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
