using System;

namespace HortifrutiBE.Business.Models.Produto
{
    public class ObterHortifruti_ProdutoResponseModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string UnidadeMedida { get; set; }
        public string Detalhes { get; set; }
    }
}
