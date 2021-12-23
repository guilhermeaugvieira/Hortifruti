using System;

namespace HortifrutiBE.Business.Models.ItemPedido
{
    public class ObterItemPedidoResponseModel
    {
        public Guid Id { get; set; }
        public Guid IdPedido { get; set; }
        public Guid IdItemEstoque { get; set; }
    }
}
