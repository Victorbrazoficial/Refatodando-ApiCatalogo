namespace Catalogo.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public DateTime DataAniversario { get; set; }
        public DateTime DataCadastro { get; set; }

        public User()
        {
            DataCadastro = DateTime.Now;
        }

        public void Update(string nome, string email, string password, string role, DateTime dataAniversario)
        {
            NomeCompleto = nome;
            Email = email;
            Password = password;
            Role = role;
            DataAniversario = dataAniversario;
        }
    }
}
