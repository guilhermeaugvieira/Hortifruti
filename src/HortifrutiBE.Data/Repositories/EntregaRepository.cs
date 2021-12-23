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
    public class EntregaRepository : IEntregaRepository
    {
        private readonly DbSet<Entrega> _db;
        private readonly IBaseRepository<Entrega> _baseRepository;

        public EntregaRepository(ApplicationContext context, IBaseRepository<Entrega> baseRepository)
        {
            _db = context.Set<Entrega>();
            _baseRepository = baseRepository;
        }

        public async Task AdicionarEntregaAsync (Entrega novaEntrega)
        {
            await _baseRepository.Adicionar(novaEntrega);
        }

        public async Task<Entrega> ProcurarUmAsync(Expression<Func<Entrega, bool>> filtro)
        {
            return await _db.Where(filtro)
                .Include(e => e.Pedido)
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entrega>> ProcurarAsync(Expression<Func<Entrega, bool>> filtro)
        {
            return await _db.Where(filtro)
                .Include(e => e.Pedido)
                .Include(e => e.Endereco)
                .ToListAsync();
        }

    }
}
