using System.Threading.Tasks;
using HortifrutiBE.Data.Context;
using HortifrutiBE.Data.Interfaces.Base;

namespace HortifrutiBE.Data.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
