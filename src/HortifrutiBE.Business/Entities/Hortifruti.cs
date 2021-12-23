using HortifrutiBE.Business.Entities.Base;
using System;
using System.Collections.Generic;

namespace HortifrutiBE.Business.Entities
{
    public class Hortifruti : BaseEntity
    {
        public string Nome { get; set; }
        public Guid IdEndereco { get; set; }
        public Guid IdProprietario { get; set; }
        public Guid IdTelefone { get; set; }
        public string CNPJ { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Usuario Proprietario { get; set; }
        public virtual Telefone Telefone { get; set; }
        public virtual IEnumerable<Produto> Produtos { get; set; }
    }
}
