using System.Threading.Tasks;
using AutoMapper;
using HortifrutiBE.Application.Interfaces;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Business.Entities.Validations;
using HortifrutiBE.Business.Interfaces;
using HortifrutiBE.Business.Models.Usuario;
using HortifrutiBE.Business.Models.UsuarioEndereco;
using HortifrutiBE.Data.Interfaces;
using HortifrutiBE.Data.Interfaces.Base;

namespace HortifrutiBE.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUser _aspNetUser;
        private readonly IUsuarioEnderecoRepository _usuarioEnderecoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITelefoneRepository _telefoneRepository;
        private readonly IDomainBaseService _domainBaseService;
        private readonly INotificador _notificador;

        public UsuarioApplicationService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IUser aspNetUser, 
            IUsuarioEnderecoRepository usuarioEnderecoRepository, 
            IDomainBaseService domainBaseService, 
            IUsuarioRepository usuarioRepository, 
            ITelefoneRepository telefoneRepository, 
            INotificador notificador)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _aspNetUser = aspNetUser;
            _usuarioEnderecoRepository = usuarioEnderecoRepository;
            _domainBaseService = domainBaseService;
            _usuarioRepository = usuarioRepository;
            _telefoneRepository = telefoneRepository;
            _notificador = notificador;
        }

        public async Task<AdicionarUsuarioEnderecoResponseModel> AddUsuario(AdicionarUsuarioEnderecoRequestModel dadosUsuario)
        {
          
            if (await _usuarioRepository.ProcurarUmAsync(
                x => x.IdentityId.Equals(
                    _aspNetUser.GetUserId()
                )) != null)
            {
                _notificador.AdicionarNotificacao("Já existe usuário criado associado ao login");
                return null;
            }

            if (await _usuarioRepository.ProcurarUmAsync(
                x => x.CPF.Equals(
                    dadosUsuario.Usuario.CPF
                )) != null)
            {
                _notificador.AdicionarNotificacao("O CPF do usuário já foi cadastrado");
                return null;
            }

            if (await _telefoneRepository.ProcurarUmAsync(
                x => x.Numero.Equals(
                    dadosUsuario.Usuario.Telefone.Numero
                )) != null)
            {
                _notificador.AdicionarNotificacao("O telefone do usuário já foi cadastrado");
                return null;
            }

            var usuarioAdicionado = _mapper.Map<UsuarioEndereco>(dadosUsuario);

            usuarioAdicionado.IdUsuario = usuarioAdicionado.Usuario.Id;
            usuarioAdicionado.IdEndereco = usuarioAdicionado.Endereco.Id;
            usuarioAdicionado.Usuario.IdTelefone = usuarioAdicionado.Usuario.Telefone.Id;
            usuarioAdicionado.Usuario.IdentityId = _aspNetUser.GetUserId();

            if (!_domainBaseService.ExecutarValidacao(
                new UsuarioEnderecoValidation(),
                usuarioAdicionado))
            {
                return null;
            }

            await _usuarioEnderecoRepository.AdicionarUsuarioEnderecoAsync(usuarioAdicionado);

            await _unitOfWork.Commit();

            return _mapper.Map<AdicionarUsuarioEnderecoResponseModel>(usuarioAdicionado);
        }

        public async Task<ObterUsuarioResponseModel> ObterUsuarioLogado()
        {
            return _mapper.Map<ObterUsuarioResponseModel>(await _usuarioRepository.ProcurarUmAsync(x => x.IdentityId == _aspNetUser.GetUserId()));
        }
    }
}