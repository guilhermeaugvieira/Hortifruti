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
    public class HortifrutiRepository : IHortifrutiRepository
    {
        private readonly DbSet<Hortifruti> _db;
        private readonly IBaseRepository<Hortifruti> _baseRepository;

        public HortifrutiRepository(ApplicationContext context, IBaseRepository<Hortifruti> baseRepository)
        {
            _db = context.Set<Hortifruti>();
            _baseRepository = baseRepository;
        }

        public async Task AdicionarHortifrutiAsync (Hortifruti novaHortifruti)
        {
            await _baseRepository.Adicionar(novaHortifruti);
        }

        public async Task<Hortifruti> ProcurarUmAsync(Expression<Func<Hortifruti, bool>> filtro)
        {
            return await _db.Where(filtro)
                .Include(e => e.Produtos)
                .Include(e => e.Endereco)
                .Include(e => e.Telefone)
                .Include(e => e.Proprietario)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Hortifruti>> ProcurarAsync(Expression<Func<Hortifruti, bool>> filtro)
        {
            return await _db.Where(filtro)
                .Include(e => e.Produtos)
                .Include(e => e.Endereco)
                .Include(e => e.Telefone)
                .Include(e => e.Proprietario)
                .ToListAsync();
        }

    }
}
