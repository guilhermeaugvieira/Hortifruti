using System;
using HortifrutiBE.Business.Models.Endereco;
using HortifrutiBE.Business.Models.Usuario;

namespace HortifrutiBE.Business.Models.UsuarioEndereco
{
    public class AdicionarUsuarioEnderecoResponseModel
    {
        public Guid Id { get; set; }
        public AdicionarUsuarioResponseModel Usuario { get; set; }
        public AdicionarEnderecoResponseModel Endereco { get; set; }
    }
}