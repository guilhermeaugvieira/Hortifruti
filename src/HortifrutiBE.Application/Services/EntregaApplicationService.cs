using AutoMapper;
using HortifrutiBE.Application.Interfaces;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Business.Entities.Validations;
using HortifrutiBE.Business.Interfaces;
using HortifrutiBE.Business.Models.Entrega;
using HortifrutiBE.Business.Models.Pedido;
using HortifrutiBE.Data.Interfaces;
using HortifrutiBE.Data.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HortifrutiBE.Application.Services
{
    public class EntregaApplicationService : IEntregaApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUser _aspNetUser;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IDomainBaseService _domainBaseService;
        private readonly INotificador _notificador;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IUsuarioEnderecoRepository _usuarioEnderecoRepository;
        private readonly IEntregaRepository _entregaRepository;

        public EntregaApplicationService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IUser aspNetUser,
            IDomainBaseService domainBaseService,
            IUsuarioRepository usuarioRepository,
            INotificador notificador,
            IPedidoRepository pedidoRepository,
            IEnderecoRepository enderecoRepository,
            IUsuarioEnderecoRepository usuarioEnderecoRepository,
            IEntregaRepository entregaRepository
            
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _aspNetUser = aspNetUser;
            _domainBaseService = domainBaseService;
            _notificador = notificador;
            _pedidoRepository = pedidoRepository;
            _enderecoRepository = enderecoRepository;
            _usuarioEnderecoRepository = usuarioEnderecoRepository;
            _entregaRepository = entregaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<AdicionarEntregaResponseModel> AddEntrega(AdicionarEntregaRequestModel dadosEntrega)
        {
            var usuario = await _usuarioRepository.ProcurarUmAsync(x => x.IdentityId.Equals(_aspNetUser.GetUserId()));

            if (usuario == null)
            {
                _notificador.AdicionarNotificacao("Não há usuário cadastrado com este login");
                return null;
            }

            var endereco = await _enderecoRepository.ProcurarUmAsync(x => x.Id.Equals(dadosEntrega.IdEndereco));

            if ( endereco == null)
            {
                _notificador.AdicionarNotificacao("Este endereço não está cadastrado");
                return null;
            }

            var pedido = await _pedidoRepository.ProcurarUmAsync(x => x.Id.Equals(dadosEntrega.IdPedido));

            if ( pedido == null)
            {
                _notificador.AdicionarNotificacao("Esse pedido não está cadastrado");
                return null;
            }

            var associacaoEndereco = await _usuarioEnderecoRepository.ProcurarUmAsync(
                x =>
                    x.IdUsuario.Equals(usuario.Id)
                    && x.IdEndereco.Equals(endereco.Id)
                );

            if (associacaoEndereco == null)
            {
                _notificador.AdicionarNotificacao("Este endereço não está associado ao seu usuário");
                return null;
            }

            var entrega = await _entregaRepository.ProcurarUmAsync(x => x.IdPedido.Equals(dadosEntrega.IdPedido));

            if(entrega != null)
            {
                _notificador.AdicionarNotificacao("Esse pedido já foi entregue");
                return null;
            }

            var novaEntrega = _mapper.Map<Entrega>(dadosEntrega);
            novaEntrega.Status = "Aguardando envio";

            if (!_domainBaseService.ExecutarValidacao(new EntregaValidation(), novaEntrega))
            {
                return null;
            }

            await _entregaRepository.AdicionarEntregaAsync(novaEntrega);

            await _unitOfWork.Commit();

            return _mapper.Map<AdicionarEntregaResponseModel>(novaEntrega);

        }

        public async Task<IEnumerable<ObterEntregaResponseModel>> ObterTodasEntregas()
        {
            return _mapper.Map<IEnumerable<ObterEntregaResponseModel>>(await _entregaRepository.ProcurarAsync(x => x.Id != Guid.Empty));
        }

        public async Task<ObterEntregaResponseModel> ObterEntregaPorId(Guid idEntrega)
        {
            return _mapper.Map<ObterEntregaResponseModel>(await _entregaRepository.ProcurarUmAsync(x => x.Id == idEntrega));
        }
    }
}