using HortifrutiBE.Business.Models.ItemPedido;
using System;
using System.Collections.Generic;

namespace HortifrutiBE.Business.Models.Pedido
{
    public class AdicionarPedidoResponseModel
    {
        public Guid Id { get; set; }
        public IEnumerable<AdicionarItemPedidoResponseModel> ItensPedido { get; set; }
    }
}