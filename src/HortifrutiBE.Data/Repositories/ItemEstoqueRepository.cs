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
    public class ItemEstoqueRepository : IItemEstoqueRepository
    {
        private readonly DbSet<ItemEstoque> _db;
        private readonly IBaseRepository<ItemEstoque> _baseRepository;

        public ItemEstoqueRepository(ApplicationContext context, IBaseRepository<ItemEstoque> baseRepository)
        {
            _db = context.Set<ItemEstoque>();
            _baseRepository = baseRepository;
        }

        public async Task<ItemEstoque> ProcurarUmAsync(Expression<Func<ItemEstoque, bool>> filtro)
        {
            return await _baseRepository.ProcurarUmAsync(filtro);
        }

        public async Task AdicionarItensEstoqueAsync(List<ItemEstoque> itens)
        {
            await _db.AddRangeAsync(itens);
        }

        public async Task<IEnumerable<ItemEstoque>> ProcurarAsync(Expression<Func<ItemEstoque, bool>> filtro)
        {
            return await _baseRepository.ProcurarAsync(filtro);
        }
    }
}
