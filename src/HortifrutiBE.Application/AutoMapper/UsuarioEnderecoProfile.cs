using AutoMapper;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Business.Models.UsuarioEndereco;

namespace HortifrutiBE.Application.AutoMapper
{
    public class UsuarioEnderecoProfile : Profile
    {
        public UsuarioEnderecoProfile()
        {
            CreateMap<AdicionarUsuarioEnderecoRequestModel, UsuarioEndereco>();
            CreateMap<UsuarioEndereco, AdicionarUsuarioEnderecoResponseModel>();
            CreateMap<UsuarioEndereco, ObterUsuario_UsuarioEnderecoResponseModel>();
            CreateMap<UsuarioEndereco, ObterUsuarioEnderecoResponseModel>();
        }
    }
}