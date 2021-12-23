using System;

namespace HortifrutiBE.Business.Models.ItemEstoque
{
    public class AdicionarItemEstoqueResponseModel
    {
        public Guid Id { get; set; }
        public Guid IdProduto { get; set; }
        public double Valor { get; set; }
    }
}