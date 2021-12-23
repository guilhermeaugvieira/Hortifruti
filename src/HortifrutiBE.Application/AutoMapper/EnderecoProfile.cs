using AutoMapper;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Business.Models.Endereco;

namespace HortifrutiBE.Application.AutoMapper
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<AdicionarEnderecoRequestModel, Endereco>();
            CreateMap<Endereco, AdicionarEnderecoResponseModel>();
            CreateMap<Endereco, ObterEnderecoResponseModel>();
        }
    }
}