using HortifrutiBE.Business.Models.ItemEstoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifrutiBE.Business.Models.Produto
{
    public class ObterProdutoResponseModel
    {
        public Guid Id { get; set; }
        public Guid IdHortifruti { get; set; }
        public string Nome { get; set; }
        public string UnidadeMedida { get; set; }
        public string Detalhes { get; set; }
        public IEnumerable<ObterProduto_ItemEstoqueResponseModel> ItensEstoque { get; set; }
    }
}
