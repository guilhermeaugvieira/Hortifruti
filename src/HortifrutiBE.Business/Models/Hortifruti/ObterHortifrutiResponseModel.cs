using HortifrutiBE.Business.Models.Endereco;
using HortifrutiBE.Business.Models.Produto;
using HortifrutiBE.Business.Models.Telefone;
using HortifrutiBE.Business.Models.Usuario;
using System;
using System.Collections.Generic;

namespace HortifrutiBE.Business.Models.Hortifruti
{
    public class ObterHortifrutiResponseModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public ObterEnderecoResponseModel Endereco { get; set; }
        public ObterHortifruti_UsuarioResponseModel Proprietario { get; set; }
        public ObterTelefoneResponseModel Telefone { get; set; }
        public IEnumerable<ObterHortifruti_ProdutoResponseModel> Produtos { get; set; }
    }
}
