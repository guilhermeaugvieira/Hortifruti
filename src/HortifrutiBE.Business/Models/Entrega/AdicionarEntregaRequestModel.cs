using System;
using System.ComponentModel.DataAnnotations;

namespace HortifrutiBE.Business.Models.Entrega
{
    public class AdicionarEntregaRequestModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid IdPedido { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid IdEndereco { get; set; }

    }
}
