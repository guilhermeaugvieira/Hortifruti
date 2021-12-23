using HortifrutiBE.Business.Models.ItemPedido;
using HortifrutiBE.Business.Models.Usuario;
using System;
using System.Collections.Generic;

namespace HortifrutiBE.Business.Models.Pedido
{
    public class ObterPedidoResponseModel
    {
        public Guid Id { get; set; }
        public virtual IEnumerable<ObterPedido_ItemPedidoResponseModel> ItensPedido { get; set; }
        public virtual ObterPedido_UsuarioResponseModel Comprador { get; set; }
    }
}
