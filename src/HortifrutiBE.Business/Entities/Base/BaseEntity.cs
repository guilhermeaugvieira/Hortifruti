using System;

namespace HortifrutiBE.Business.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
            UltimaAtualizacao = null;
        }
    }
}
