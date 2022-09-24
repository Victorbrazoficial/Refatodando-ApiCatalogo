using MediatR;

namespace Catalogo.Application.Commands.ProdutoCommand
{
    public class ExcluirProdutoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
