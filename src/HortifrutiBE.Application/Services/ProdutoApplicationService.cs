using AutoMapper;
using HortifrutiBE.Application.Interfaces;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Business.Entities.Validations;
using HortifrutiBE.Business.Interfaces;
using HortifrutiBE.Business.Models.ItemEstoque;
using HortifrutiBE.Business.Models.Produto;
using HortifrutiBE.Data.Interfaces;
using HortifrutiBE.Data.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HortifrutiBE.Application.Services
{
    public class ProdutoApplicationService : IProdutoApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHortifrutiRepository _hortifrutiRepository;
        private readonly IDomainBaseService _domainBaseService;
        private readonly INotificador _notificador;
        private readonly IUser _aspNetUser;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ProdutoApplicationService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHortifrutiRepository hortifrutiRepository,
            IDomainBaseService domainBaseService,
            INotificador notificador,
            IUser aspNetUser, IProdutoRepository produtoRepository, 
            IUsuarioRepository usuarioRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hortifrutiRepository = hortifrutiRepository;
            _domainBaseService = domainBaseService;
            _notificador = notificador;
            _aspNetUser = aspNetUser;
            _produtoRepository = produtoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<AdicionarProdutoResponseModel> AddProduto(AdicionarProdutoRequestModel dadosProduto, Guid idHortifruti)
        {
            var hortifruti = await _hortifrutiRepository.ProcurarUmAsync(x => x.Id.Equals(idHortifruti));

            if ( hortifruti == null)
            {
                _notificador.AdicionarNotificacao("Hortifruti não existe");
                return null;
            }

            var usuario = await _usuarioRepository.ProcurarUmAsync(x => x.IdentityId.Equals(_aspNetUser.GetUserId()));

            if (usuario == null)
            {
                _notificador.AdicionarNotificacao("Não existe usuário associado ao seu login");
                return null;
            }
            
            if ( hortifruti.IdProprietario != usuario.Id)
            {
                _notificador.AdicionarNotificacao("Só é permitido ao proprietário adicionar produtos");
                return null;
            }

            var novoProduto = _mapper.Map<Produto>(dadosProduto);

            novoProduto.IdHortifruti = idHortifruti;

            if(!_domainBaseService.ExecutarValidacao(new ProdutoValidation(), novoProduto))
            {
                return null;
            }

            await _produtoRepository.AdicionarProdutoAsync(novoProduto);

            await _unitOfWork.Commit();

            return _mapper.Map<AdicionarProdutoResponseModel>(novoProduto);
        }

        public async Task<IEnumerable<ObterProdutoResponseModel>> ObterTodosProdutos(Guid idHortifruti)
        {
            return _mapper.Map<IEnumerable<ObterProdutoResponseModel>>(await _produtoRepository.ProcurarAsync(x => x.IdHortifruti == idHortifruti));
        }

        public async Task<ObterProdutoResponseModel> ObterProdutoPorId(Guid idHortifruti, Guid idProduto)
        {
            return _mapper.Map<ObterProdutoResponseModel>(await _produtoRepository.ProcurarUmAsync(x => x.IdHortifruti == idHortifruti && x.Id == idProduto));
        }
    }
}