using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HortifrutiBE.Business.Entities;

namespace HortifrutiBE.Data.Interfaces
{
    public interface IPedidoRepository
    {
        Task AdicionarPedidoAsync(Pedido novoPedido);

        Task<Pedido> ProcurarUmAsync(Expression<Func<Pedido, bool>> filtro);

        Task<IEnumerable<Pedido>> ProcurarAsync(Expression<Func<Pedido, bool>> filtro);
    }
}
