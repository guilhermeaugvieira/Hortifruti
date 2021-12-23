using System;
using System.Collections.Generic;
using HortifrutiBE.Business.Entities.Base;

namespace HortifrutiBE.Business.Entities
{
    public class Pedido : BaseEntity
    {
        public Guid IdComprador { get; set; }
        public virtual IEnumerable<ItemPedido> ItensPedido{ get; set; }
        public virtual Usuario Comprador { get; set; }
        public virtual Entrega Entrega { get; set; }
    }
}
