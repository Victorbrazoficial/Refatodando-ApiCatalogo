using Catalogo.Application.ViewModels;
using MediatR;

namespace Catalogo.Application.Commands.LoginUserCommand
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
