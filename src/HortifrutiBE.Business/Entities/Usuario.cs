using HortifrutiBE.Business.Entities.Base;
using System;
using System.Collections.Generic;

namespace HortifrutiBE.Business.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid IdentityId { get; set; }
        public Guid IdTelefone { get; set; }
        public string CPF { get; set; }
        public virtual IEnumerable<UsuarioEndereco> Enderecos { get; set; }
        public virtual Telefone Telefone { get; set; }
        public virtual IEnumerable<Hortifruti> Hortifrutis { get; set; }
        public virtual IEnumerable<Pedido> Pedidos { get; set; }
    }
}
