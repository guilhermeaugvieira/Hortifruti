using AutoMapper;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Business.Models.ItemEstoque;

namespace HortifrutiBE.Application.AutoMapper
{
    public class ItemEstoqueProfile : Profile
    {
        public ItemEstoqueProfile()
        {
            CreateMap<AdicionarItemEstoqueRequestModel, ItemEstoque>();
            CreateMap<ItemEstoque, AdicionarItemEstoqueResponseModel>();
            CreateMap<ItemEstoque, ObterPedido_ItemEstoqueResponseModel>();
            CreateMap<ItemEstoque, ObterProduto_ItemEstoqueResponseModel>();
            CreateMap<ItemEstoque, ObterItemEstoqueResponseModel>();
        }
    }
}