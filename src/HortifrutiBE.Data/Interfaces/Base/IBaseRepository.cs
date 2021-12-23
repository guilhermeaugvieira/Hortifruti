using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HortifrutiBE.Data.Interfaces.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Adicionar(TEntity entidade);

        void Atualizar(TEntity entidade);

        public void Remover(TEntity entidade);

        Task<List<TEntity>> ProcurarAsync(Expression<Func<TEntity, bool>> filtro);

        Task<TEntity> ProcurarUmAsync(Expression<Func<TEntity, bool>> filtro);
    }
}
