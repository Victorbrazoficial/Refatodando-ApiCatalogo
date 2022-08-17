namespace Catalogo.Application.ViewModels
{
    public class CategoriaViewModel
    {
        public string Nome { get; set; }

        public CategoriaViewModel(string nome)
        {
            Nome = nome;
        }
    }
}
