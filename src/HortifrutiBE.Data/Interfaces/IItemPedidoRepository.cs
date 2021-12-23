using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HortifrutiBE.Business.Entities;

namespace HortifrutiBE.Data.Interfaces
{
    public interface IItemPedidoRepository
    {
        Task AdicionarItensPedidoAsync(List<ItemPedido> itens);
        Task<ItemPedido> ProcurarUmAsync(Expression<Func<ItemPedido, bool>> filtro);
        Task<IEnumerable<ItemPedido>> ProcurarAsync(Expression<Func<ItemPedido, bool>> filtro);
    }
}
