﻿using Catalogo.Application.Commands.CategoriaCommand;
using FluentValidation;

namespace Catalogo.Application.Validations
{
    public class CadastrarCategoriaCommandValidator : AbstractValidator<CadastrarCategoriaCommand>
    {
        public CadastrarCategoriaCommandValidator()
        {
            RuleFor(c => c.Nome)
                .MaximumLength(30)
                .WithMessage("Nome não pode ter mais que 20 caracteres.");

            RuleFor(c => c.ImagemUrl)
                .MaximumLength(34)
                .WithMessage("ImagemUrl não pode ter mais que 20 caracteres.");     
        }
    }
}
