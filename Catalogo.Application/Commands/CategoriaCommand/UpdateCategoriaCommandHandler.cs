using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using MediatR;

namespace Catalogo.Application.Commands.CategoriaCommand
{
    public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand,Unit>
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public UpdateCategoriaCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Unit> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoriaAtualizada = new Categoria()
            {
                CategoriaId = request.Id,
                Nome = request.Nome,
                ImagemUrl = request.ImagemUrl
            };

            await _categoriaRepository.Update(categoriaAtualizada);

            return Unit.Value;
        }
    }
}
