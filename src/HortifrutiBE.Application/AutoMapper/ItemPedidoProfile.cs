using AutoMapper;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Business.Models.ItemPedido;

namespace HortifrutiBE.Application.AutoMapper
{
    public class ItemPedidoProfile : Profile
    {
        public ItemPedidoProfile()
        {
            CreateMap<AdicionarItemPedidoRequestModel, ItemPedido>();
            CreateMap<ItemPedido, AdicionarItemPedidoResponseModel>();
            CreateMap<ItemPedido, ObterPedido_ItemPedidoResponseModel>();
            CreateMap<ItemPedido, ObterItemPedidoResponseModel>();
        }
    }
}
