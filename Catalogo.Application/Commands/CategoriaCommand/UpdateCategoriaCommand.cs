using MediatR;

namespace Catalogo.Application.Commands.CategoriaCommand
{
    public class UpdateCategoriaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? ImagemUrl { get; set; }
    }
}
