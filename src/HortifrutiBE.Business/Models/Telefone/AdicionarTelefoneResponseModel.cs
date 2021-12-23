using System;

namespace HortifrutiBE.Business.Models.Telefone
{
    public class AdicionarTelefoneResponseModel
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }
        public bool WhatsApp { get; set; }
    }
}