using HortifrutiBE.Business.Entities;
using HortifrutiBE.Data.Context;
using HortifrutiBE.Data.Interfaces;
using HortifrutiBE.Data.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HortifrutiBE.Data.Repositories
{
    public class UsuarioEnderecoRepository : IUsuarioEnderecoRepository
    {
        private readonly DbSet<UsuarioEndereco> _db;
        private readonly IBaseRepository<UsuarioEndereco> _baseRepository;

        public UsuarioEnderecoRepository(ApplicationContext context, IBaseRepository<UsuarioEndereco> baseRepository)
        {
            _db = context.Set<UsuarioEndereco>();
            _baseRepository = baseRepository;
        }

        public async Task AdicionarUsuarioEnderecoAsync (UsuarioEndereco novaAssociacao)
        {
            await _baseRepository.Adicionar(novaAssociacao);
        }

        public async Task<IEnumerable<UsuarioEndereco>> ProcurarAsync(Expression<Func<UsuarioEndereco, bool>> filtro)
        {
            return await _baseRepository.ProcurarAsync(filtro);
        }

        public async Task<UsuarioEndereco> ProcurarUmAsync(Expression<Func<UsuarioEndereco, bool>> filtro)
        {
            return await _baseRepository.ProcurarUmAsync(filtro);
        }
    }
}
