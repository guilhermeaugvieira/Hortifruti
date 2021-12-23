using AutoMapper;
using HortifrutiBE.Application.Interfaces;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Business.Entities.Validations;
using HortifrutiBE.Business.Interfaces;
using HortifrutiBE.Business.Models.Pedido;
using HortifrutiBE.Data.Interfaces;
using HortifrutiBE.Data.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HortifrutiBE.Application.Services
{
    public class PedidoApplicationService : IPedidoApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUser _aspNetUser;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IDomainBaseService _domainBaseService;
        private readonly INotificador _notificador;
        private readonly IItemEstoqueRepository _itemEstoqueRepository;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoApplicationService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IUser aspNetUser,
            IDomainBaseService domainBaseService,
            IUsuarioRepository usuarioRepository,
            INotificador notificador,
            IItemEstoqueRepository itemEstoqueRepository,
            IItemPedidoRepository itemPedidoRepository,
            IPedidoRepository pedidoRepository
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _aspNetUser = aspNetUser;
            _domainBaseService = domainBaseService;
            _usuarioRepository = usuarioRepository;
            _notificador = notificador;
            _itemEstoqueRepository = itemEstoqueRepository;
            _itemPedidoRepository = itemPedidoRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<AdicionarPedidoResponseModel> AddPedido(AdicionarPedidoRequestModel dadosPedido)
        {
            var usuario = await _usuarioRepository.ProcurarUmAsync(x => x.IdentityId.Equals(_aspNetUser.GetUserId()));

            if (usuario.Equals(null))
            {
                _notificador.AdicionarNotificacao("Não existe usuário cadastrado com esse login");
                return null;
            }

            foreach (var item in dadosPedido.ItensPedido)
            {
                var itemEstoque = await _itemEstoqueRepository.ProcurarUmAsync(x => x.Id.Equals(item.IdItemEstoque));
                
                if (itemEstoque.Equals(null))
                {
                    _notificador.AdicionarNotificacao("O item do estoque não existe");
                    return null;
                }

                if (await _itemPedidoRepository.ProcurarUmAsync(x => x.IdItemEstoque.Equals(item.IdItemEstoque)) != null)
                {
                    _notificador.AdicionarNotificacao($"O item do estoque {item.IdItemEstoque} já foi vendido");
                    return null;
                }
            }
            
            var novoPedido = _mapper.Map<Pedido>(dadosPedido);

            novoPedido.Comprador = usuario;
            novoPedido.IdComprador = usuario.Id;

            foreach(var itemPedido in novoPedido.ItensPedido)
            {
                itemPedido.IdPedido = novoPedido.Id;

                if (!_domainBaseService.ExecutarValidacao(new ItemPedidoValidation(), itemPedido))
                {
                    return null;
                }
            }

            if (!_domainBaseService.ExecutarValidacao(new PedidoValidation(), novoPedido))
            {
                return null;
            }

            await _pedidoRepository.AdicionarPedidoAsync(novoPedido);

            await _unitOfWork.Commit();

            return _mapper.Map<AdicionarPedidoResponseModel>(novoPedido);
        }

        public async Task<IEnumerable<ObterPedidoResponseModel>> ObterTodosPedidos()
        {
            var usuario = await _usuarioRepository.ProcurarUmAsync(x => x.IdentityId.Equals(_aspNetUser.GetUserId()));

            return _mapper.Map<IEnumerable<ObterPedidoResponseModel>>(await _pedidoRepository.ProcurarAsync(x => x.IdComprador == usuario.Id));
        }

        public async Task<ObterPedidoResponseModel> ObterPedidoPorId(Guid idPedido)
        {
            var usuario = await _usuarioRepository.ProcurarUmAsync(x => x.IdentityId.Equals(_aspNetUser.GetUserId()));

            return _mapper.Map<ObterPedidoResponseModel>(await _pedidoRepository.ProcurarUmAsync(x => x.IdComprador == usuario.Id && x.Id == idPedido));
        }
    }
}