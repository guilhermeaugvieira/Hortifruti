using System;
using FluentValidation;
using HortifrutiBE.Business.Entities.Base;

namespace HortifrutiBE.Business.Entities.Validations
{
    public class EntregaValidation : BaseValidation<Entrega>
    {
        public EntregaValidation() : base()
        {
            RuleFor(c => c.IdPedido)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEqual(Guid.Empty).WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");

            RuleFor(c => c.IdEndereco)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEqual(Guid.Empty).WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");

            RuleFor(c => c.Status)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Envio)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("O campo {PropertyName} precisa ser maior que {PropertyValue}");

            RuleFor(c => c.Recebimento)
                .GreaterThanOrEqualTo(c => c.Envio).WithMessage("O campo {PropertyName} precisa ser maior que {PropertyValue}");

            RuleFor(c => c.Pedido)
                .SetValidator(new PedidoValidation());

            RuleFor(c => c.Endereco)
                .SetValidator(new EnderecoValidation());
        }
    }
}
