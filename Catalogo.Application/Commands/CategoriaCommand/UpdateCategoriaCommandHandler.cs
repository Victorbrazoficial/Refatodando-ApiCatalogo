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
            var categoria = await _categoriaRepository.GetByIdDetalhesAsync(request.Id);

            categoria.Update(request.Nome, request.ImagemUrl);

            await _categoriaRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
