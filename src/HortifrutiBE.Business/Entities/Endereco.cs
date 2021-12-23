using System;
using System.Collections.Generic;
using HortifrutiBE.Business.Entities.Base;

namespace HortifrutiBE.Business.Entities
{
    public class Endereco : BaseEntity
    {
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public int Numero { get; set; }
        public virtual IEnumerable<UsuarioEndereco> Usuarios { get; set; }
        public virtual Hortifruti Hortifruti { get; set; }
        public virtual IEnumerable<Entrega> Entregas { get; set; }

    }
}
