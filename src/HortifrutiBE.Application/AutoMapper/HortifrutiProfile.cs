using AutoMapper;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Business.Models.Hortifruti;

namespace HortifrutiBE.Application.AutoMapper
{
    public class HortifrutiProfile : Profile
    {
        public HortifrutiProfile()
        {
            CreateMap<AdicionarHortifrutiRequestModel, Hortifruti>();
            CreateMap<Hortifruti, AdicionarHortifrutiResponseModel>();
            CreateMap<Hortifruti, ObterHortifrutiResponseModel>();
        }
    }
}