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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DbSet<Produto> _db;
        private readonly IBaseRepository<Produto> _baseRepository;

        public ProdutoRepository(ApplicationContext context, IBaseRepository<Produto> baseRepository)
        {
            _db = context.Set<Produto>();
            _baseRepository = baseRepository;
        }

        public async Task AdicionarProdutoAsync (Produto novoProduto)
        {
            await _baseRepository.Adicionar(novoProduto);
        }

        public async Task<Produto> ProcurarUmAsync(Expression<Func<Produto, bool>> filtro)
        {
            return await _db.Where(filtro)
                .Include(e => e.ItensEstoque)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Produto>> ProcurarAsync(Expression<Func<Produto, bool>> filtro)
        {
            return await _db.Where(filtro)
                .Include(e => e.ItensEstoque)
                .ToListAsync();
        }

    }
}
