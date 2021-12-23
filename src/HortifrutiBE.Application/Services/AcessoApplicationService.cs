using System.Threading.Tasks;
using AutoMapper;
using HortifrutiBE.Application.Interfaces;
using HortifrutiBE.Business.Interfaces;
using HortifrutiBE.Business.Models.UsuarioIdentity;
using HortifrutiBE.Business.Notificacoes;
using HortifrutiBE.InfraStructure.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HortifrutiBE.Application.Services
{
    public class AcessoApplicationService : IAcessoApplicationService
    {
        private readonly INotificador _notificador;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public AcessoApplicationService(
            INotificador notificador,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IJwtService jwtService,
            IMapper mapper)
        {
            _notificador = notificador;
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public async Task<string> LoginAsync(LoginUsuarioRequestModel loginUsuario)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUsuario.Email, loginUsuario.Senha, false, true);

            if (result.Succeeded)
            {
                return await _jwtService.GerarJwt(loginUsuario.Email);
            }

            if (result.IsLockedOut)
            {
                _notificador.AdicionarNotificacao("Usuário temporariamente bloqueado por tentativas inválidas");
                return null;
            }

            _notificador.AdicionarNotificacao("Usuário ou senha incorreto");
            return null;
        }

        public async Task<string> AdicionarAsync(AdicionarUsuarioLoginRequestModel novoUsuario)
        {
            var user = new IdentityUser
            {
                UserName = novoUsuario.Email,
                Email = novoUsuario.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, novoUsuario.Senha);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);

                return await _jwtService.GerarJwt(user.Email);
            }

            foreach (var error in result.Errors)
            {
                _notificador.AdicionarNotificacao(error.Description);
            }

            return null;
        }
    }
}
