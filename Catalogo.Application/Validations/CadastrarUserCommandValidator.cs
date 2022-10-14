using Catalogo.Application.Commands.UserCommand;
using FluentValidation;

namespace Catalogo.Application.Validations
{
    public class CadastrarUserCommandValidator : AbstractValidator<CadastrarUserCommand>
    {
        public CadastrarUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage($"E-mail invalido");

            RuleFor(u => u.Password)
                .MinimumLength(8)
                .MaximumLength(8)
                .WithMessage($"Senha invalida. Digite apenas 8 caracteres.");
        }
    }
}
