using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HortifrutiBE.Business.Entities;

namespace HortifrutiBE.Data.Interfaces
{
    public interface IEnderecoRepository
    {
        Task AdicionarEnderecoAsync(Endereco novoEndereco);

        Task<Endereco> ProcurarUmAsync(Expression<Func<Endereco, bool>> filtro);

        Task<IEnumerable<Endereco>> ProcurarAsync(Expression<Func<Endereco, bool>> filtro);
    }
}
