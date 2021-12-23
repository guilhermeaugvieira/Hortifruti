using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HortifrutiBE.Business.Entities;

namespace HortifrutiBE.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AdicionarUsuarioAsync(Usuario novoUsuario);

        Task<Usuario> ProcurarUmAsync(Expression<Func<Usuario, bool>> filtro);

        Task<IEnumerable<Usuario>> ProcurarAsync(Expression<Func<Usuario, bool>> filtro);
    }
}
