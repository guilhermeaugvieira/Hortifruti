using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Data.Context;
using HortifrutiBE.Data.Interfaces;
using HortifrutiBE.Data.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace HortifrutiBE.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DbSet<Pedido> _db;
        private readonly IBaseRepository<Pedido> _baseRepository;

        public PedidoRepository(ApplicationContext context, IBaseRepository<Pedido> baseRepository)
        {
            _db = context.Set<Pedido>();
            _baseRepository = baseRepository;
        }

        public async Task AdicionarPedidoAsync (Pedido novoPedido)
        {
            await _baseRepository.Adicionar(novoPedido);
        }

        public async Task<Pedido> ProcurarUmAsync(Expression<Func<Pedido, bool>> filtro)
        {
            return await _db.Where(filtro)
                .Include(e => e.ItensPedido)
                    .ThenInclude(e => e.ItemEstoque)
                .Include(e => e.Comprador)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Pedido>> ProcurarAsync(Expression<Func<Pedido, bool>> filtro)
        {
            return await _db.Where(filtro)
                .Include(e => e.ItensPedido)
                    .ThenInclude(e => e.ItemEstoque)
                .Include(e => e.Comprador)
                .ToListAsync();
        }

    }
}
