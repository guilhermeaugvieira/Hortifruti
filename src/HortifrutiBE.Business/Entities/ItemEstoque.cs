using System;
using HortifrutiBE.Business.Entities.Base;

namespace HortifrutiBE.Business.Entities
{
    public class ItemEstoque : BaseEntity
    {
        public Guid IdProduto { get; set; }
        public double Valor { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual ItemPedido ItemPedido { get; set; }
    }
}
