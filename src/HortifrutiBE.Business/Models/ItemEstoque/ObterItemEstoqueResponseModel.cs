using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifrutiBE.Business.Models.ItemEstoque
{
    public class ObterItemEstoqueResponseModel
    {
        public Guid Id { get; set; }
        public Guid IdProduto { get; set; }
        public double Valor { get; set; }
    }
}
