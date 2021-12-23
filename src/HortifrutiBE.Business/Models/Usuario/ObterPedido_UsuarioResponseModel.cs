using System;

namespace HortifrutiBE.Business.Models.Usuario
{
    public class ObterPedido_UsuarioResponseModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid IdentityId { get; set; }
        public string CPF { get; set; }
    }
}
