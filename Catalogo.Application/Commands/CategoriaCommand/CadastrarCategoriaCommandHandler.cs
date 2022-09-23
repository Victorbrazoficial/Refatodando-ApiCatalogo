using Catalogo.Core.Entities;
using Catalogo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Application.Commands.CategoriaCommand
{
    public class CadastrarCategoriaCommandHandler : IRequestHandler<CadastrarCategoriaCommand, int>
    {
        private readonly CatalogoDbContext _catalogoDbContext;
        public CadastrarCategoriaCommandHandler(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }
        public async Task<int> Handle(CadastrarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = new Categoria() { CategoriaId = request.CategoriaId, Nome = request.Nome, ImagemUrl = request.ImagemUrl };

            await _catalogoDbContext.Categorias.AddAsync(categoria);

            await _catalogoDbContext.SaveChangesAsync();

            return categoria.CategoriaId;
        }
    }
}
