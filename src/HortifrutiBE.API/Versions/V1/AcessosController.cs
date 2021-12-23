using HortifrutiBE.API.Controllers;
using HortifrutiBE.Application.Interfaces;
using HortifrutiBE.Business.Interfaces;
using HortifrutiBE.Business.Models.Base;
using HortifrutiBE.Business.Models.UsuarioIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HortifrutiBE.API.Versions.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class AcessosController : BaseController
    {
        private readonly IAcessoApplicationService _acessoApplicationService;

        public AcessosController(INotificador notificador, IAcessoApplicationService acessoApplicationService) : base(notificador)
        {
            _acessoApplicationService = acessoApplicationService;
        }

        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<string>))]
        [Produces("application/json")]
        [HttpPost("Usuario")]
        
        public async Task<ActionResult> AddUsuarioIdentity(AdicionarUsuarioLoginRequestModel novoUsuario)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida(ModelState);
                return BadRequest(new ErrorVM(ObterErros()));
            }

            var result = await _acessoApplicationService.AdicionarAsync(novoUsuario);

            if (result == null)
            {
                return BadRequest(new ErrorVM(ObterErros()));
            }

            return Ok(new SuccessVM<string>(result));
        }

        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<string>))]
        [Produces("application/json")]
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginUsuarioRequestModel loginUsuario)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida(ModelState);
                return BadRequest(new ErrorVM(ObterErros()));
            }

            var result = await _acessoApplicationService.LoginAsync(loginUsuario);

            if (result == null)
            {
                return BadRequest(new ErrorVM(ObterErros()));
            }

            return Ok(new SuccessVM<string>(result));
        }
    }
}
