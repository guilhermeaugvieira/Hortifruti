using System;
using FluentValidation;
using HortifrutiBE.Business.Entities.Base;

namespace HortifrutiBE.Business.Entities.Validations
{
    public class PedidoValidation : BaseValidation<Pedido>
    {
        public PedidoValidation() : base()
        {
            RuleFor(c => c.IdComprador)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEqual(Guid.Empty).WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");

            RuleFor(c => c.Comprador)
                .SetValidator(new UsuarioValidation());
        }
    }
}
