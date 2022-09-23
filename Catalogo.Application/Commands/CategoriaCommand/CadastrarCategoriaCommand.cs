using MediatR;

namespace Catalogo.Application.Commands.CategoriaCommand
{
    public class CadastrarCategoriaCommand : IRequest<int>
    {
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? ImagemUrl { get; set; }
    }
}
