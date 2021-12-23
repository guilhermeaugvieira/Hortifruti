using System;

namespace HortifrutiBE.Business.Models.Endereco
{
    public class AdicionarEnderecoResponseModel
    {
        public Guid Id { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public int Numero { get; set; }
    }
}