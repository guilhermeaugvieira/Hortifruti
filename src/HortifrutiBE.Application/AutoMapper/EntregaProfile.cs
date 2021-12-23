using AutoMapper;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Business.Models.Entrega;

namespace HortifrutiBE.Application.AutoMapper
{
    public class EntregaProfile : Profile
    {
        public EntregaProfile()
        {
            CreateMap<AdicionarEntregaRequestModel, Entrega>();
            CreateMap<Entrega, AdicionarEntregaResponseModel>();
            CreateMap<Entrega, ObterEntregaResponseModel>();
        }
    }
}