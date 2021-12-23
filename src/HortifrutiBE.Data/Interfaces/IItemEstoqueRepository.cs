using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HortifrutiBE.Business.Entities;

namespace HortifrutiBE.Data.Interfaces
{
    public interface IItemEstoqueRepository
    {
        Task AdicionarItensEstoqueAsync(List<ItemEstoque> itens);
        Task<ItemEstoque> ProcurarUmAsync(Expression<Func<ItemEstoque, bool>> filtro);
        Task<IEnumerable<ItemEstoque>> ProcurarAsync(Expression<Func<ItemEstoque, bool>> filtro);


    }
}
