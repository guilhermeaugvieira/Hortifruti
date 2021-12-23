using System;
using System.ComponentModel.DataAnnotations;

namespace HortifrutiBE.Business.Models.Entrega
{
    public class AtualizarEntregaRequestModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Status { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo precisa ser preenchido com {1}")]
        public DateTime? Envio { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo precisa ser preenchido com {1}")]
        public DateTime? Recebimento { get; set; }
    }
}
