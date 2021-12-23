using System;
using HortifrutiBE.Business.Entities.Base;

namespace HortifrutiBE.Business.Entities
{
    public class Entrega : BaseEntity
    {
        public Guid IdPedido { get; set; }
        public Guid IdEndereco { get; set; }
        public string Status { get; set; }
        public DateTime? Envio { get; set; }
        public DateTime? Recebimento { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
