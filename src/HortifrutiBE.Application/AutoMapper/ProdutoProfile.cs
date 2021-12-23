using AutoMapper;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Business.Models.Produto;

namespace HortifrutiBE.Application.AutoMapper
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<AdicionarProdutoRequestModel, Produto>();
            CreateMap<Produto, AdicionarProdutoResponseModel>();
            CreateMap<Produto, ObterHortifruti_ProdutoResponseModel>();
            CreateMap<Produto, ObterProdutoResponseModel>();
        }
    }
}