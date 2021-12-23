using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HortifrutiBE.Business.Entities;

namespace HortifrutiBE.Data.Interfaces
{
    public interface ITelefoneRepository
    {
        Task AdicionarTelefoneAsync(Telefone novoTelefone);

        Task<Telefone> ProcurarUmAsync(Expression<Func<Telefone, bool>> filtro);

        Task<IEnumerable<Telefone>> ProcurarAsync(Expression<Func<Telefone, bool>> filtro);
    }
}
