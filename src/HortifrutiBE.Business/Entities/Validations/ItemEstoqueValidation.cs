using System;
using FluentValidation;
using HortifrutiBE.Business.Entities.Base;

namespace HortifrutiBE.Business.Entities.Validations
{
    public class ItemEstoqueValidation : BaseValidation<ItemEstoque>
    {
        public ItemEstoqueValidation() : base()
        {
            RuleFor(c => c.IdProduto)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEqual(Guid.Empty).WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");

            RuleFor(c => c.Valor)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.Produto)
                .SetValidator(new ProdutoValidation());
        }
    }
}
