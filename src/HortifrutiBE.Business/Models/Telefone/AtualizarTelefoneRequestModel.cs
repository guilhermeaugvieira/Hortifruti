using System;
using System.ComponentModel.DataAnnotations;

namespace HortifrutiBE.Business.Models.Telefone
{
    public class AtualizarTelefoneRequestModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string Numero { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool WhatsApp { get; set; }
    }
}
