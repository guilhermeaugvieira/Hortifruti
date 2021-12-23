using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HortifrutiBE.Business.Entities;

namespace HortifrutiBE.Data.Interfaces
{
    public interface IProdutoRepository
    {
        Task AdicionarProdutoAsync(Produto novoProduto);

        Task<Produto> ProcurarUmAsync(Expression<Func<Produto, bool>> filtro);

        Task<IEnumerable<Produto>> ProcurarAsync(Expression<Func<Produto, bool>> filtro);
    }
}
