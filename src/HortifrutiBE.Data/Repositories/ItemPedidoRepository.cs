using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Data.Context;
using HortifrutiBE.Data.Interfaces;
using HortifrutiBE.Data.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace HortifrutiBE.Data.Repositories
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly DbSet<ItemPedido> _db;
        private readonly IBaseRepository<ItemPedido> _baseRepository;

        public ItemPedidoRepository(ApplicationContext context, IBaseRepository<ItemPedido> baseRepository)
        {
            _db = context.Set<ItemPedido>();
            _baseRepository = baseRepository;
        }

        public async Task<ItemPedido> ProcurarUmAsync(Expression<Func<ItemPedido, bool>> filtro)
        {
            return await _baseRepository.ProcurarUmAsync(filtro);
        }

        public async Task AdicionarItensPedidoAsync(List<ItemPedido> itens)
        {
            await _db.AddRangeAsync(itens);
        }

        public async Task<IEnumerable<ItemPedido>> ProcurarAsync(Expression<Func<ItemPedido, bool>> filtro)
        {
            return await _baseRepository.ProcurarAsync(filtro);
        }
    }
}
