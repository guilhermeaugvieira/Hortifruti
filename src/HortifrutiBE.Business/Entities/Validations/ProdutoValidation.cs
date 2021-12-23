using System;
using FluentValidation;
using HortifrutiBE.Business.Entities.Base;

namespace HortifrutiBE.Business.Entities.Validations
{
    public class ProdutoValidation : BaseValidation<Produto>
    {
        public ProdutoValidation() : base()
        {
            RuleFor(c => c.IdHortifruti)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEqual(Guid.Empty).WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");

            RuleFor(c => c.Nome)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.UnidadeMedida)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 10).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Detalhes)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Hortifruti)
                .SetValidator(new HortifrutiValidation());
        }
    }
}
