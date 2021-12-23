using FluentValidation;
using HortifrutiBE.Business.Entities.Base;

namespace HortifrutiBE.Business.Interfaces
{
    public interface IDomainBaseService
    {
        bool ExecutarValidacao<TValidator, TEntity>(TValidator validacao, TEntity entidade) where TValidator : AbstractValidator<TEntity> where TEntity : BaseEntity;
    }
}
