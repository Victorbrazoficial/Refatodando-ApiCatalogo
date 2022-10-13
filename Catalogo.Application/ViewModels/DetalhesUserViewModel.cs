namespace Catalogo.Application.ViewModels
{
    public class DetalhesUserViewModel
    {
        public int Id { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public DateTime DataAniversario { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
