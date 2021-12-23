using HortifrutiBE.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HortifrutiBE.Data.Interfaces
{
    public interface IHortifrutiRepository
    {
        Task AdicionarHortifrutiAsync(Hortifruti novaHortifruti);

        Task<Hortifruti> ProcurarUmAsync(Expression<Func<Hortifruti, bool>> filtro);

        Task<IEnumerable<Hortifruti>> ProcurarAsync(Expression<Func<Hortifruti, bool>> filtro);
    }
}
