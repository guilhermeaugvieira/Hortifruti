using HortifrutiBE.Business.Models.ItemEstoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifrutiBE.Business.Models.ItemPedido
{
    public class ObterPedido_ItemPedidoResponseModel
    {
        public Guid Id { get; set; }
        public ObterPedido_ItemEstoqueResponseModel ItemEstoque { get; set; }
    }
}
