using FluentValidation;
using HortifrutiBE.Business.Entities.Base;

namespace HortifrutiBE.Business.Entities.Validations
{
    public class TelefoneValidation : BaseValidation<Telefone>
    {
        public TelefoneValidation() : base()
        {
            RuleFor(c => c.Numero)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.WhatsApp)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
