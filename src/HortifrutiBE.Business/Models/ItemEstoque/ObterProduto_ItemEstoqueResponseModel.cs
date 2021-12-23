using System;

namespace HortifrutiBE.Business.Models.ItemEstoque
{
    public class ObterProduto_ItemEstoqueResponseModel
    {
        public Guid Id { get; set; }
        public Guid IdProduto { get; set; }
        public double Valor { get; set; }
    }
}
