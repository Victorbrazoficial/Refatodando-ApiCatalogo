using System.Collections.ObjectModel;

namespace Catalogo.Core.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? ImagemUrl { get; set; }
        public ICollection<Produto>? Produtos { get; set; }
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }

        public void Update(string nome, string imagemUrl)
        {
            Nome = nome;
            ImagemUrl = imagemUrl;
        }
    }
}
