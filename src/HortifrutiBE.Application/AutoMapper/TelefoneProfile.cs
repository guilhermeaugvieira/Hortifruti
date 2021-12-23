using AutoMapper;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Business.Models.Telefone;

namespace HortifrutiBE.Application.AutoMapper
{
    public class TelefoneProfile : Profile
    {
        public TelefoneProfile()
        {
            CreateMap<AdicionarTelefoneRequestModel, Telefone>();
            CreateMap<Telefone, AdicionarTelefoneResponseModel>();
            CreateMap<Telefone, ObterTelefoneResponseModel>();
        }
    }
}
