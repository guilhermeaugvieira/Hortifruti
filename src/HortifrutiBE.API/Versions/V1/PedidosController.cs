using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HortifrutiBE.API.Controllers;
using HortifrutiBE.Application.Interfaces;
using HortifrutiBE.Business.Interfaces;
using HortifrutiBE.Business.Models.Base;
using HortifrutiBE.Business.Models.Pedido;
using HortifrutiBE.Business.Models.UsuarioEndereco;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HortifrutiBE.API.Versions.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class PedidosController : BaseController
    {
        private readonly IPedidoApplicationService _pedidoApplicationService;

        public PedidosController(INotificador notificador, IPedidoApplicationService pedidoApplicationService) : base(notificador)
        {
            _pedidoApplicationService = pedidoApplicationService;
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<AdicionarPedidoResponseModel>))]
        [HttpPost]
        public async Task<ActionResult<AdicionarPedidoResponseModel>> AddPedido(AdicionarPedidoRequestModel dadosPedido)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida(ModelState);
                return BadRequest(new ErrorVM(ObterErros()));
            }

            var resposta = await _pedidoApplicationService.AddPedido(dadosPedido);

            return RespostaBase(resposta);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<IEnumerable<ObterPedidoResponseModel>>))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObterPedidoResponseModel>>> ObterTodosPedidos()
        {
            var resposta = await _pedidoApplicationService.ObterTodosPedidos();

            return RespostaBase(resposta);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<ObterPedidoResponseModel>))]
        [HttpGet("{idPedido:guid}")]
        public async Task<ActionResult<IEnumerable<ObterPedidoResponseModel>>> ObterPedidoPorId(Guid idPedido)
        {
            var resposta = await _pedidoApplicationService.ObterPedidoPorId(idPedido);

            return RespostaBase(resposta);
        }

    }
}