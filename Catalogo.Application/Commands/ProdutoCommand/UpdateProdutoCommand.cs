using MediatR;

namespace Catalogo.Application.Commands.ProdutoCommand
{
    public class UpdateProdutoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public string? ImagemUrl { get; set; }
        public int CategoriaId { get; set; }
    }
}
