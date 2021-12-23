using System;
using FluentValidation;

namespace HortifrutiBE.Business.Entities.Base
{
    public abstract class BaseValidation<TEntity> : AbstractValidator<TEntity> where TEntity : BaseEntity
    {
        protected BaseValidation()
        {
            RuleFor(c => c.Id)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEqual(Guid.Empty).WithMessage("O campo {PropertyName} deve ser preenchido")
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");

            RuleFor(c => c.DataCadastro)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEqual(default(DateTime)).WithMessage("O campo {PropertyName} precisa ser uma data válida");

            RuleFor(c => c.UltimaAtualizacao)
                .NotEqual(default(DateTime)).WithMessage("O campo {PropertyName} precisa ser uma data válida")
                .GreaterThanOrEqualTo(c => c.DataCadastro);
        }
    }
}
