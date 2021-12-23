using HortifrutiBE.API.Controllers;
using HortifrutiBE.Application.Interfaces;
using HortifrutiBE.Business.Interfaces;
using HortifrutiBE.Business.Models.Base;
using HortifrutiBE.Business.Models.Hortifruti;
using HortifrutiBE.Business.Models.ItemEstoque;
using HortifrutiBE.Business.Models.Produto;
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
    public class HortifrutisController : BaseController
    {
        private readonly IHortifrutiApplicationService _hortifrutiApplicationService;
        private readonly IProdutoApplicationService _produtoApplicationService;
        private readonly IItemEstoqueApplicationService _itemEstoqueApplicationService;

        public HortifrutisController(
            INotificador notificador,
            IHortifrutiApplicationService hortifrutiApplicationService,
            IProdutoApplicationService produtoApplicationService, IItemEstoqueApplicationService itemEstoqueApplicationService) : base(notificador)
        {
            _hortifrutiApplicationService = hortifrutiApplicationService;
            _produtoApplicationService = produtoApplicationService;
            _itemEstoqueApplicationService = itemEstoqueApplicationService;
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<AdicionarHortifrutiResponseModel>))]
        [HttpPost]
        public async Task<ActionResult<AdicionarHortifrutiResponseModel>> AddHortifruti(AdicionarHortifrutiRequestModel dadosHortifruti)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida(ModelState);
                return BadRequest(new ErrorVM(ObterErros()));
            }

            var resposta = await _hortifrutiApplicationService.AddHortifruti(dadosHortifruti);

            return RespostaBase(resposta);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<AdicionarProdutoResponseModel>))]
        [HttpPost("{idHortifruti:guid}/Produtos")]
        public async Task<ActionResult<AdicionarProdutoResponseModel>> AddProduto(AdicionarProdutoRequestModel dadosProduto, Guid idHortifruti)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida(ModelState);
                return BadRequest(new ErrorVM(ObterErros()));
            }

            var resposta = await _produtoApplicationService.AddProduto(dadosProduto, idHortifruti);

            return RespostaBase(resposta);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<IEnumerable<AdicionarItemEstoqueResponseModel>>))]
        [HttpPost("{idHortifruti:guid}/Produtos/{idProduto}/ItemEstoque")]
        public async Task<ActionResult<IEnumerable<AdicionarItemEstoqueResponseModel>>> AddItemEstoque(AdicionarItemEstoqueRequestModel dadosItemEstoque, Guid idHortifruti, Guid idProduto)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida(ModelState);
                return BadRequest(new ErrorVM(ObterErros()));
            }

            var resposta = await _itemEstoqueApplicationService.AddItemEstoque(dadosItemEstoque, idHortifruti, idProduto);

            return RespostaBase(resposta);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<IEnumerable<ObterHortifrutiResponseModel>>))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObterHortifrutiResponseModel>>> ObterTodasHortifrutis()
        {
            var response = await _hortifrutiApplicationService.ObterTodasHortifrutis();

            return RespostaBase(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<ObterHortifrutiResponseModel>))]
        [HttpGet("{idHortifruti:guid}")]
        public async Task<ActionResult<IEnumerable<ObterHortifrutiResponseModel>>> ObterHortifrutiPorId(Guid idHortifruti)
        {
            var response = await _hortifrutiApplicationService.ObterHortifrutiPorId(idHortifruti);

            return RespostaBase(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<IEnumerable<ObterProdutoResponseModel>>))]
        [HttpGet("{idHortifruti:guid}/Produtos")]
        public async Task<ActionResult<IEnumerable<ObterHortifrutiResponseModel>>> ObterTodosProdutos(Guid idHortifruti)
        {
            var response = await _produtoApplicationService.ObterTodosProdutos(idHortifruti);

            return RespostaBase(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<ObterProdutoResponseModel>))]
        [HttpGet("{idHortifruti:guid}/Produtos/{idProduto:guid}")]
        public async Task<ActionResult<IEnumerable<ObterHortifrutiResponseModel>>> ObterProdutoPorId(Guid idHortifruti, Guid idProduto)
        {
            var response = await _produtoApplicationService.ObterProdutoPorId(idHortifruti, idProduto);

            return RespostaBase(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<IEnumerable<ObterItemEstoqueResponseModel>>))]
        [HttpGet("{idHortifruti:guid}/Produtos/{idProduto:guid}/ItemEstoque")]
        public async Task<ActionResult<IEnumerable<ObterHortifrutiResponseModel>>> ObterTodosProdutos(Guid idHortifruti, Guid idProduto)
        {
            var response = await _itemEstoqueApplicationService.ObterTodosItemEstoques(idHortifruti, idProduto);

            return RespostaBase(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorVM))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessVM<ObterItemEstoqueResponseModel>))]
        [HttpGet("{idHortifruti:guid}/Produtos/{idProduto:guid}/ItemEstoque/{idItemEstoque:guid}")]
        public async Task<ActionResult<IEnumerable<ObterHortifrutiResponseModel>>> ObterProdutoPorId(Guid idHortifruti, Guid idProduto, Guid idItemEstoque)
        {
            var response = await _itemEstoqueApplicationService.ObterItemEstoquePorId(idHortifruti, idProduto, idItemEstoque);

            return RespostaBase(response);
        }

    }
}