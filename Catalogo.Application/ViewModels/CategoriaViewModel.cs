using Catalogo.Core.Entities;

namespace Catalogo.Application.ViewModels
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? ImagemUrl { get; set; }
        public ICollection<Produto>? Produtos { get; set; }

        public CategoriaViewModel(int id, string nome, string imagemUrl, ICollection<Produto> produtos)
        {
            Id = id;
            Nome = nome;
            ImagemUrl = imagemUrl;
            Produtos = produtos;
        }
    }
}
