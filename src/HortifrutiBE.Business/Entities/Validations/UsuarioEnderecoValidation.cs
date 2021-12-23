using System;
using FluentValidation;
using HortifrutiBE.Business.Entities.Base;

namespace HortifrutiBE.Business.Entities.Validations
{
    public class UsuarioEnderecoValidation : BaseValidation<UsuarioEndereco>
    {
        public UsuarioEnderecoValidation() : base()
        {
            RuleFor(c => c.IdUsuario)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEqual(Guid.Empty).WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");

            RuleFor(c => c.IdEndereco)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEqual(Guid.Empty).WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Usuario)
                .SetValidator(new UsuarioValidation());

            RuleFor(c => c.Endereco)
                .SetValidator(new EnderecoValidation());
        }
    }
}
