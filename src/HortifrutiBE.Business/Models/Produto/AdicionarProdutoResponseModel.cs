using System;

namespace HortifrutiBE.Business.Models.Produto
{
    public class AdicionarProdutoResponseModel
    {
        public Guid Id { get; set; }
        public Guid IdHortifruti { get; set; }
        public string Nome { get; set; }
        public string UnidadeMedida { get; set; }
        public string Detalhes { get; set; }
    }
}