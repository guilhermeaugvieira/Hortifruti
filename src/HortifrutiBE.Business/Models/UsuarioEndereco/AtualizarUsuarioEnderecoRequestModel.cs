using System;
using System.ComponentModel.DataAnnotations;
using HortifrutiBE.Business.Models.Endereco;
using HortifrutiBE.Business.Models.Usuario;

namespace HortifrutiBE.Business.Models.UsuarioEndereco
{
    public class AtualizarUsuarioEnderecoRequestModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public AtualizarUsuarioRequestModel Usuario { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public AtualizarEnderecoRequestModel Endereco { get; set; }
    }
}