using Catalogo.Core.Entities;

namespace Catalogo.Application.ViewModels
{
    public class DetalhesCategoriaIdViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? ImagemUrl { get; set; }
        public ICollection<Produto>? Produtos { get; set; }
    }
}
