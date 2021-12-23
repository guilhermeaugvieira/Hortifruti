using System.Threading.Tasks;

namespace HortifrutiBE.Data.Interfaces.Base
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        Task Rollback();
    }
}
