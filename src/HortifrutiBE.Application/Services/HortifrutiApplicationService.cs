using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HortifrutiBE.Application.Interfaces;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Business.Entities.Validations;
using HortifrutiBE.Business.Interfaces;
using HortifrutiBE.Business.Models.Hortifruti;
using HortifrutiBE.Business.Models.UsuarioEndereco;
using HortifrutiBE.Data.Interfaces;
using HortifrutiBE.Data.Interfaces.Base;

namespace HortifrutiBE.Application.Services
{
    public class HortifrutiApplicationService : IHortifrutiApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUser _aspNetUser;
        private readonly IHortifrutiRepository _hortifrutiRepository;
        private readonly IDomainBaseService _domainBaseService;
        private readonly INotificador _notificador;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITelefoneRepository _telefoneRepository;

        public HortifrutiApplicationService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IUser aspNetUser,
            IHortifrutiRepository hortifrutiRepository,
            IDomainBaseService domainBaseService,
            INotificador notificador,
            IUsuarioRepository usuarioRepository,
            ITelefoneRepository telefoneRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _aspNetUser = aspNetUser;
            _hortifrutiRepository = hortifrutiRepository;
            _domainBaseService = domainBaseService;
            _notificador = notificador;
            _usuarioRepository = usuarioRepository;
            _telefoneRepository = telefoneRepository;
        }

        public async Task<AdicionarHortifrutiResponseModel> AddHortifruti(AdicionarHortifrutiRequestModel dadosHortifruti)
        {
            if (await _telefoneRepository.ProcurarUmAsync(
                x => x.Numero.Equals(
                    dadosHortifruti.Telefone.Numero
                )) != null)
            {
                _notificador.AdicionarNotificacao("O telefone da hortifruti já foi cadastrado");
                return null;
            }

            if (await _hortifrutiRepository.ProcurarUmAsync(
                x => x.CNPJ.Equals(
                    dadosHortifruti.CNPJ
                )) != null)
            {
                _notificador.AdicionarNotificacao("O CNPJ da hortifruti já foi cadastrado");
                return null;
            }

            var usuarioLogado = await _usuarioRepository.ProcurarUmAsync(x => x.IdentityId.Equals(_aspNetUser.GetUserId()));
            
            var hortifrutiAdicionada = _mapper.Map<Hortifruti>(dadosHortifruti);

            hortifrutiAdicionada.IdEndereco = hortifrutiAdicionada.Endereco.Id;
            hortifrutiAdicionada.IdTelefone = hortifrutiAdicionada.Telefone.Id;
            hortifrutiAdicionada.IdProprietario = usuarioLogado.Id;

            if (!_domainBaseService.ExecutarValidacao(new HortifrutiValidation(), hortifrutiAdicionada))
            {
                return null;
            }

            await _hortifrutiRepository.AdicionarHortifrutiAsync(hortifrutiAdicionada);

            await _unitOfWork.Commit();

            return _mapper.Map<AdicionarHortifrutiResponseModel>(hortifrutiAdicionada);
        }

        public async Task<IEnumerable<ObterHortifrutiResponseModel>> ObterTodasHortifrutis()
        {
            return _mapper.Map<IEnumerable<ObterHortifrutiResponseModel>>(await _hortifrutiRepository.ProcurarAsync(x => x.Id != System.Guid.Empty));
        }

        public async Task<ObterHortifrutiResponseModel> ObterHortifrutiPorId(Guid idHortifruti)
        {
            return _mapper.Map<ObterHortifrutiResponseModel>(await _hortifrutiRepository.ProcurarUmAsync(x => x.Id == idHortifruti));
        }
    }
}