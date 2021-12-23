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
    public class ItemEstoqueApplicationService : IItemEstoqueApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHortifrutiRepository _hortifrutiRepository;
        private readonly IDomainBaseService _domainBaseService;
        private readonly INotificador _notificador;
        private readonly IUser _aspNetUser;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IItemEstoqueRepository _itemEstoqueRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ItemEstoqueApplicationService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHortifrutiRepository hortifrutiRepository,
            IDomainBaseService domainBaseService,
            INotificador notificador,
            IUser aspNetUser, IItemEstoqueRepository itemEstoqueRepository,
            IProdutoRepository produtoRepository,
            IUsuarioRepository usuarioRepository
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hortifrutiRepository = hortifrutiRepository;
            _domainBaseService = domainBaseService;
            _notificador = notificador;
            _aspNetUser = aspNetUser;
            _itemEstoqueRepository = itemEstoqueRepository;
            _produtoRepository = produtoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<AdicionarItemEstoqueResponseModel>> AddItemEstoque(AdicionarItemEstoqueRequestModel itemEstoque, Guid idHortifruti, Guid idProduto)
        {
            var hortifruti = await _hortifrutiRepository.ProcurarUmAsync(
                    x => x.Id == idHortifruti
                );

            if (hortifruti == null)
            {
                _notificador.AdicionarNotificacao("Hortifruti não encontrada");
                return null;
            }

            var usuario = await _usuarioRepository.ProcurarUmAsync(x => x.IdentityId.Equals(_aspNetUser.GetUserId()));

            if (usuario == null)
            {
                _notificador.AdicionarNotificacao("Não existe usuário associado ao seu login");
                return null;
            }

            if (hortifruti.IdProprietario != usuario.Id)
            {
                _notificador.AdicionarNotificacao("Só é permitido ao proprietário adicionar produtos");
                return null;
            }

            var produto = await _produtoRepository.ProcurarUmAsync(x => x.Id == idProduto);

            if (produto == null)
            {
                _notificador.AdicionarNotificacao("Produto não encontrado");
                return null;
            }

            if (produto.IdHortifruti != idHortifruti)
            {
                _notificador.AdicionarNotificacao("Este produto só pode ser gerenciado pela hortifruti proprietária");
                return null;
            }

            List<ItemEstoque> itensEstoque = new List<ItemEstoque>();

            for(int i = 0; i < itemEstoque.Quantidade; i++)
            {
                var item = _mapper.Map<ItemEstoque>(itemEstoque);
                item.IdProduto = idProduto;

                itensEstoque.Add(item);
            }

            foreach(var item in itensEstoque)
            {
                if(!_domainBaseService.ExecutarValidacao(new ItemEstoqueValidation(), item))
                {
                    return null;
                }
            }

            await _itemEstoqueRepository.AdicionarItensEstoqueAsync(itensEstoque);

            await _unitOfWork.Commit();

            return _mapper.Map<IEnumerable<AdicionarItemEstoqueResponseModel>>(itensEstoque);
        }

        public async Task<IEnumerable<ObterItemEstoqueResponseModel>> ObterTodosItemEstoques(Guid idHortifruti, Guid idProduto)
        {
            return _mapper.Map<IEnumerable<ObterItemEstoqueResponseModel>>(await _itemEstoqueRepository.ProcurarAsync(x => x.IdProduto == idProduto && x.Produto.IdHortifruti == idHortifruti));
        }

        public async Task<ObterItemEstoqueResponseModel> ObterItemEstoquePorId(Guid idHortifruti, Guid idProduto, Guid idItemEstoque)
        {
            return _mapper.Map<ObterItemEstoqueResponseModel>(await _itemEstoqueRepository.ProcurarUmAsync(x => x.IdProduto == idProduto && x.Produto.IdHortifruti == idHortifruti && x.Id == idItemEstoque));
        }
    }
}