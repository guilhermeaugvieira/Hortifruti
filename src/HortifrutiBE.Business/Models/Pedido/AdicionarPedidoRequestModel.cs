using HortifrutiBE.Business.Models.ItemPedido;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HortifrutiBE.Business.Models.Pedido
{
    public class AdicionarPedidoRequestModel
    {
        public IEnumerable<AdicionarItemPedidoRequestModel> ItensPedido { get; set; }
    }
}