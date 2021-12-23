using FluentValidation;
using FluentValidation.Results;
using HortifrutiBE.Business.Entities.Base;
using HortifrutiBE.Business.Interfaces;
using HortifrutiBE.Business.Notificacoes;

namespace HortifrutiBE.Business.Services.Base
{
    public class DomainBaseService : IDomainBaseService
    {
        private readonly INotificador _notificador;

        public DomainBaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        private void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        private void Notificar(string mensagem)
        {
            _notificador.AdicionarNotificacao(mensagem);
        }

        public bool ExecutarValidacao<TValidator, TEntity>(TValidator validacao, TEntity entidade) 
            where TValidator : AbstractValidator<TEntity> 
            where TEntity : BaseEntity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
