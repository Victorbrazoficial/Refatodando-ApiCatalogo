using Catalogo.Core.Repositories;
using Catalogo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Application.Commands.CategoriaCommand
{
    public class ExcluirCategoriaCommandHandler : IRequestHandler<ExcluirCategoriaCommand, Unit>
    {

        private readonly ICategoriaRepository _categoriaRepository;

        public ExcluirCategoriaCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Unit> Handle(ExcluirCategoriaCommand request, CancellationToken cancellationToken)
        {
            await _categoriaRepository.Excluir(request.Id);
            
            return Unit.Value;
        }
    }
}
