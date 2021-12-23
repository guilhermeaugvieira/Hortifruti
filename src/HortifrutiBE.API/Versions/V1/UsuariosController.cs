using System.Threading.Tasks;
using HortifrutiBE.API.Controllers;
using HortifrutiBE.Application.Interfaces;
using HortifrutiBE.Business.Interfaces;
using HortifrutiBE.Business.Models.Base;
using HortifrutiBE.Business.Models.Usuario;
using HortifrutiBE.Business.Models.UsuarioEndereco;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HortifrutiBE.API.Versions.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioApplicationService _usuarioApplicationService;
        
        public UsuariosController(INotificador notificador, IUsuarioApplicationService usuarioApplicationService) : base(notificador)
        {
            _usuarioApplicationService = usuarioApplicationService;
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<AdicionarUsuarioEnderecoResponseModel>))]
        [HttpPost]
        public async Task<ActionResult<AdicionarUsuarioEnderecoResponseModel>> AddDadosUsuario(AdicionarUsuarioEnderecoRequestModel dadosUsuario)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida(ModelState);
                return BadRequest(new ErrorVM(ObterErros()));
            }

            var resposta = await _usuarioApplicationService.AddUsuario(dadosUsuario);

            return RespostaBase(resposta);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<ObterUsuarioResponseModel>))]
        [HttpGet]
        public async Task<ActionResult<ObterUsuarioResponseModel>> ObterUsuarioLogado()
        {
            var resposta =  await _usuarioApplicationService.ObterUsuarioLogado();

            return RespostaBase(resposta);
        }

    }
}