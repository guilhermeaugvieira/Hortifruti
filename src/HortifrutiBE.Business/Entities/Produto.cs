using System;
using System.Collections.Generic;
using HortifrutiBE.Business.Entities.Base;

namespace HortifrutiBE.Business.Entities
{
    public class Produto : BaseEntity
    {
        public Guid IdHortifruti { get; set; }
        public string Nome { get; set; }
        public string UnidadeMedida { get; set; }
        public string Detalhes { get; set; }
        public virtual Hortifruti Hortifruti { get; set; }
        public virtual IEnumerable<ItemEstoque> ItensEstoque { get; set; }
    }
}
