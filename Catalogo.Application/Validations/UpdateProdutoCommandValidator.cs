using Catalogo.Application.Commands.ProdutoCommand;
using FluentValidation;

namespace Catalogo.Application.Validations
{
    public class UpdateProdutoCommandValidator : AbstractValidator<UpdateProdutoCommand>
    {
        public UpdateProdutoCommandValidator()
        {
            RuleFor(c => c.Nome)
                .MaximumLength(30)
                .WithMessage("Nome não pode ter mais que 20 caracteres.");

            RuleFor(c => c.Descricao)
                .MaximumLength(255)
                .WithMessage("Descrição não pode ter mais que 255 caracteres.");

            RuleFor(c => c.ImagemUrl)
                .MaximumLength(34)
                .WithMessage("ImagemUrl não pode ter mais que 20 caracteres.");     
        }
    }
}
