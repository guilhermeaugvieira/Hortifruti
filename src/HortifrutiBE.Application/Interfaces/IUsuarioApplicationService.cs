using System.Threading.Tasks;
using HortifrutiBE.Business.Models.Usuario;
using HortifrutiBE.Business.Models.UsuarioEndereco;

namespace HortifrutiBE.Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        Task<AdicionarUsuarioEnderecoResponseModel> AddUsuario(AdicionarUsuarioEnderecoRequestModel dadosUsuario);

        Task<ObterUsuarioResponseModel> ObterUsuarioLogado();
    }
}