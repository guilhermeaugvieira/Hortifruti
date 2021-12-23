using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HortifrutiBE.Business.Entities;

namespace HortifrutiBE.Data.Interfaces
{
    public interface IUsuarioEnderecoRepository
    {
        Task AdicionarUsuarioEnderecoAsync(UsuarioEndereco novaAssociacao);

        Task<UsuarioEndereco> ProcurarUmAsync(Expression<Func<UsuarioEndereco, bool>> filtro);

        Task<IEnumerable<UsuarioEndereco>> ProcurarAsync(Expression<Func<UsuarioEndereco, bool>> filtro);
    }
}
