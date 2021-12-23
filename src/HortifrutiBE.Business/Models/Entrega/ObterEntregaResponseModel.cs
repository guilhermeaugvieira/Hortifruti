using HortifrutiBE.Business.Models.Endereco;
using HortifrutiBE.Business.Models.Pedido;
using System;

namespace HortifrutiBE.Business.Models.Entrega
{
    public class ObterEntregaResponseModel
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime? Envio { get; set; }
        public DateTime? Recebimento { get; set; }
        public ObterEntrega_PedidoResponseModel Pedido { get; set; }
        public ObterEnderecoResponseModel Endereco { get; set; }
    }
}
