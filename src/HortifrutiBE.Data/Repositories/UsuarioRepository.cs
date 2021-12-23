using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Business.Interfaces;
using HortifrutiBE.Data.Context;
using HortifrutiBE.Data.Interfaces;
using HortifrutiBE.Data.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace HortifrutiBE.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbSet<Usuario> _db;
        private readonly IBaseRepository<Usuario> _baseRepository;

        public UsuarioRepository(ApplicationContext context, IBaseRepository<Usuario> baseRepository)
        {
            _db = context.Set<Usuario>();
            _baseRepository = baseRepository;
        }

        public async Task AdicionarUsuarioAsync (Usuario novoUsuario)
        {
            await _baseRepository.Adicionar(novoUsuario);
        }

        public async Task<Usuario> ProcurarUmAsync(Expression<Func<Usuario, bool>> filtro)
        {
            return await _db.Where(filtro)
                .Include(e => e.Enderecos)
                    .ThenInclude(e => e.Endereco)
                .Include(e => e.Telefone)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> ProcurarAsync(Expression<Func<Usuario, bool>> filtro)
        {
            return await _db.Where(filtro)
                .Include(e => e.Enderecos)
                    .ThenInclude(e => e.Endereco)
                .Include(e => e.Telefone)
                .ToListAsync();
        }
    }
}
