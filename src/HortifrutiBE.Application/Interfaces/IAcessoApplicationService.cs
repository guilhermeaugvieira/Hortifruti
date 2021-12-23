using System.Threading.Tasks;
using HortifrutiBE.Business.Models.UsuarioIdentity;

namespace HortifrutiBE.Application.Interfaces
{
    public interface IAcessoApplicationService
    {
        Task<string> LoginAsync(LoginUsuarioRequestModel loginUsuario);
        Task<string> AdicionarAsync(AdicionarUsuarioLoginRequestModel novoUsuario);
    }
}
