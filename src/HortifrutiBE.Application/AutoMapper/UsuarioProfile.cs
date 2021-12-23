using AutoMapper;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Business.Models.Usuario;

namespace HortifrutiBE.Application.AutoMapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<AdicionarUsuarioRequestModel, Usuario>();
            CreateMap<Usuario, AdicionarUsuarioResponseModel>();
            CreateMap<Usuario, ObterHortifruti_UsuarioResponseModel>();
            CreateMap<Usuario, ObterPedido_UsuarioResponseModel>();
            CreateMap<Usuario, ObterUsuarioResponseModel>();
        }
    }
}
