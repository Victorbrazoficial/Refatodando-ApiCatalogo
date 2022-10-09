using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using MediatR;

namespace Catalogo.Application.Commands.CategoriaCommand
{
    public class CadastrarCategoriaCommandHandler : IRequestHandler<CadastrarCategoriaCommand, int>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CadastrarCategoriaCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
    }
        public async Task<int> Handle(CadastrarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var novaCategoria = new Categoria()
            {
                CategoriaId = request.CategoriaId,
                Nome = request.Nome,
                ImagemUrl = request.ImagemUrl

            };

            await _categoriaRepository.Cadastrar(novaCategoria);
            await _categoriaRepository.SaveChangeAsync();

            return novaCategoria.CategoriaId;
        }
    }
}
