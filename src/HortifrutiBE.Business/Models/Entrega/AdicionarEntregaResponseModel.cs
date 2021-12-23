using System;

namespace HortifrutiBE.Business.Models.Entrega
{
    public class AdicionarEntregaResponseModel
    {
        public Guid Id { get; set; }
        public Guid IdPedido { get; set; }
        public Guid IdEndereco { get; set; }
        public string Status { get; set; }
        public DateTime? Envio { get; set; }
        public DateTime? Recebimento { get; set; }
    }
}