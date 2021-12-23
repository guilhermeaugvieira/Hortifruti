using System;
using System.ComponentModel.DataAnnotations;
using HortifrutiBE.Business.Models.Endereco;
using HortifrutiBE.Business.Models.Telefone;

namespace HortifrutiBE.Business.Models.Hortifruti
{
    public class AtualizarHortifrutiRequestModel
    {        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 14)]
        public string CNPJ { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public AtualizarEnderecoRequestModel Endereco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public AtualizarTelefoneRequestModel Telefone { get; set; }
    }
}
