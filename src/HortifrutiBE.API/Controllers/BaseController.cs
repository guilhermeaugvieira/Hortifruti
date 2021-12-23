using HortifrutiBE.Business.Interfaces;
using HortifrutiBE.Business.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace HortifrutiBE.API.Controllers
{
    [Route("v{version:ApiVersion}/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly INotificador _notificador;

        protected BaseController(INotificador notificador) : base()
        {
            _notificador = notificador;
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                _notificador.AdicionarNotificacao(errorMsg);
            }
        }

        protected IEnumerable<string> ObterErros()
        {
            return _notificador.ObterNotificacoes();
        }

        protected ActionResult RespostaBase<TResult>(TResult objetoResposta)
        {
            if (objetoResposta == null)
            {
                if (!_notificador.TemNotificacao())
                {
                    return NoContent();
                }

                return BadRequest(new ErrorVM(ObterErros()));
            }

            return Ok(new SuccessVM<TResult>(objetoResposta));
        }
    }
}
