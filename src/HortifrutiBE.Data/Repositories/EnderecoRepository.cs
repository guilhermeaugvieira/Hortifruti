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
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DbSet<Endereco> _db;
        private readonly IBaseRepository<Endereco> _baseRepository;

        public EnderecoRepository(ApplicationContext context, IBaseRepository<Endereco> baseRepository)
        {
            _db = context.Set<Endereco>();
            _baseRepository = baseRepository;
        }

        public async Task AdicionarEnderecoAsync (Endereco novoEndereco)
        {
            await _baseRepository.Adicionar(novoEndereco);
        }

        public async Task<IEnumerable<Endereco>> ProcurarAsync(Expression<Func<Endereco, bool>> filtro)
        {
            return await _baseRepository.ProcurarAsync(filtro);
        }

        public async Task<Endereco> ProcurarUmAsync(Expression<Func<Endereco, bool>> filtro)
        {
            return await _baseRepository.ProcurarUmAsync(filtro);
        }

    }
}
