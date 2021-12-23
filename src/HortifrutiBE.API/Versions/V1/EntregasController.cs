using HortifrutiBE.API.Controllers;
using HortifrutiBE.Application.Interfaces;
using HortifrutiBE.Business.Interfaces;
using HortifrutiBE.Business.Models.Base;
using HortifrutiBE.Business.Models.Entrega;
using HortifrutiBE.Business.Models.Pedido;
using HortifrutiBE.Business.Models.UsuarioEndereco;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HortifrutiBE.API.Versions.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class EntregasController : BaseController
    {
        private readonly IEntregaApplicationService _entregaApplicationService;

        public EntregasController(INotificador notificador, IEntregaApplicationService entregaApplicationService) : base(notificador)
        {
            _entregaApplicationService = entregaApplicationService;
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<AdicionarEntregaResponseModel>))]
        [HttpPost]
        public async Task<ActionResult<AdicionarEntregaResponseModel>> AddEntrega(AdicionarEntregaRequestModel dadosEntrega)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida(ModelState);
                return BadRequest(new ErrorVM(ObterErros()));
            }

            var resposta = await _entregaApplicationService.AddEntrega(dadosEntrega);

            return RespostaBase(resposta);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<IEnumerable<ObterEntregaResponseModel>>))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObterEntregaResponseModel>>> ObterTodasEntregas()
        {
            var resposta = await _entregaApplicationService.ObterTodasEntregas();

            return RespostaBase(resposta);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<ObterEntregaResponseModel>))]
        [HttpGet("{idEntrega:guid}")]
        public async Task<ActionResult<IEnumerable<ObterEntregaResponseModel>>> ObterTodasEntregas(Guid idEntrega)
        {
            var resposta = await _entregaApplicationService.ObterEntregaPorId(idEntrega);

            return RespostaBase(resposta);
        }

    }
}