using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HortifrutiBE.Business.Entities.Base;
using HortifrutiBE.Data.Context;
using HortifrutiBE.Data.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace HortifrutiBE.Data.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _db;

        public BaseRepository(ApplicationContext context)
        {
            _db = context.Set<TEntity>();
        }

        public async Task Adicionar(TEntity entidade)
        {
            await _db.AddAsync(entidade);
        }

        public void Atualizar(TEntity entidade)
        {
            _db.Update(entidade);
        }

        public void Remover(TEntity entidade)
        {
            _db.Remove(entidade);
        }

        public async Task<List<TEntity>> ProcurarAsync(Expression<Func<TEntity, bool>> filtro)
        {
            return await _db.Where(filtro).ToListAsync();
        }

        public async Task<TEntity> ProcurarUmAsync(Expression<Func<TEntity, bool>> filtro)
        {
            return await _db.Where(filtro).FirstOrDefaultAsync();
        }
    }
}
