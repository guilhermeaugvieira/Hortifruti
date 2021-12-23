using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HortifrutiBE.Business.Entities;

namespace HortifrutiBE.Data.Interfaces
{
    public interface IEntregaRepository
    {
        Task AdicionarEntregaAsync(Entrega novaEntrega);

        Task<Entrega> ProcurarUmAsync(Expression<Func<Entrega, bool>> filtro);

        Task<IEnumerable<Entrega>> ProcurarAsync(Expression<Func<Entrega, bool>> filtro);
    }
}
