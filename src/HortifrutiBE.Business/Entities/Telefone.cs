using System;
using HortifrutiBE.Business.Entities.Base;

namespace HortifrutiBE.Business.Entities
{
    public class Telefone : BaseEntity
    {
        public string Numero { get; set; }
        public bool WhatsApp { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Hortifruti Hortifruti { get; set; }
    }
}
