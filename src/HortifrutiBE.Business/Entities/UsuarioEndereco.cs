using System;
using HortifrutiBE.Business.Entities.Base;

namespace HortifrutiBE.Business.Entities
{
    public class UsuarioEndereco : BaseEntity
    {
        public Guid IdUsuario { get; set; }
        public Guid IdEndereco { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
