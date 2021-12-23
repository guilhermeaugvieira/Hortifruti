using System.ComponentModel.DataAnnotations;
using HortifrutiBE.Business.Models.Endereco;
using HortifrutiBE.Business.Models.Usuario;

namespace HortifrutiBE.Business.Models.UsuarioEndereco
{
    public class AdicionarUsuarioEnderecoRequestModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public AdicionarUsuarioRequestModel Usuario { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public AdicionarEnderecoRequestModel Endereco { get; set; }
    }
}