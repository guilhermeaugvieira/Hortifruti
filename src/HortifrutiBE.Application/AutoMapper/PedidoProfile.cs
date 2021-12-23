using AutoMapper;
using HortifrutiBE.Business.Entities;
using HortifrutiBE.Business.Models.Pedido;

namespace HortifrutiBE.Application.AutoMapper
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<AdicionarPedidoRequestModel, Pedido>();
            CreateMap<Pedido, AdicionarPedidoResponseModel>();
            CreateMap<Pedido, ObterEntrega_PedidoResponseModel>();
            CreateMap<Pedido, ObterPedidoResponseModel>();
        }
    }
}