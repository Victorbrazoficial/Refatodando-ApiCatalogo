using MediatR;

namespace Catalogo.Application.Commands.UserCommand
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public DateTime DataAniversario { get; set; }
    }
}
