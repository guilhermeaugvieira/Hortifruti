using System;
using System.Collections.Generic;
using HortifrutiBE.Business.Models.Endereco;
using HortifrutiBE.Business.Models.Telefone;

namespace HortifrutiBE.Business.Models.Hortifruti
{
    public class AdicionarHortifrutiResponseModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid IdProprietario { get; set; }
        public string CNPJ { get; set; }
        public AdicionarEnderecoResponseModel Endereco { get; set; }
        public AdicionarTelefoneResponseModel Telefone { get; set; }
    }
}