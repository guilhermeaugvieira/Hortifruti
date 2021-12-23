using HortifrutiBE.Business.Entities.Base;
using System;

namespace HortifrutiBE.Business.Entities
{
    public class ItemPedido : BaseEntity
    {
        public Guid IdPedido { get; set; }
        public Guid IdItemEstoque { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual ItemEstoque ItemEstoque { get ;set; }
    }
}
