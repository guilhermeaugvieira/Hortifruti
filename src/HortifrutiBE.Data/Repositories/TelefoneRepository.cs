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
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly DbSet<Telefone> _db;
        private readonly IBaseRepository<Telefone> _baseRepository;

        public TelefoneRepository(ApplicationContext context, IBaseRepository<Telefone> baseRepository)
        {
            _db = context.Set<Telefone>();
            _baseRepository = baseRepository;
        }

        public async Task AdicionarTelefoneAsync (Telefone novoTelefone)
        {
            await _baseRepository.Adicionar(novoTelefone);
        }

        public async Task<IEnumerable<Telefone>> ProcurarAsync(Expression<Func<Telefone, bool>> filtro)
        {
            return await _baseRepository.ProcurarAsync(filtro);
        }

        public async Task<Telefone> ProcurarUmAsync(Expression<Func<Telefone, bool>> filtro)
        {
            return await _baseRepository.ProcurarUmAsync(filtro);
        }

    }
}
