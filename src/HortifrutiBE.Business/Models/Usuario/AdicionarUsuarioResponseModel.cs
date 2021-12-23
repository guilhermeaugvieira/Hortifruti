using System;
using System.Collections.Generic;
using HortifrutiBE.Business.Models.Telefone;

namespace HortifrutiBE.Business.Models.Usuario
{
    public class AdicionarUsuarioResponseModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid IdentityId { get; set; }
        public string CPF { get; set; }
        public AdicionarTelefoneResponseModel Telefone { get; set; }
    }
}