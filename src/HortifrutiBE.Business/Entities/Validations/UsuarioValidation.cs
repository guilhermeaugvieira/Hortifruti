using System;
using FluentValidation;
using HortifrutiBE.Business.Entities.Base;

namespace HortifrutiBE.Business.Entities.Validations
{
    public class UsuarioValidation : BaseValidation<Usuario>
    {
        public UsuarioValidation() : base()
        {
            RuleFor(c => c.IdentityId)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEqual(Guid.Empty).WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");

            RuleFor(c => c.Nome)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Sobrenome)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.DataNascimento)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEqual(default(DateTime)).WithMessage("O campo {PropertyName} precisa ser válido");

            RuleFor(c => c.IdTelefone)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEqual(Guid.Empty).WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.CPF)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(11).WithMessage("O campo {PropertyName} precisa ter {ComparisonValue} caracteres");

            RuleFor(c => c.Telefone)
                .SetValidator(new TelefoneValidation());
        }
    }
}
