using HortifrutiBE.Business.Models.Endereco;
using System;

namespace HortifrutiBE.Business.Models.UsuarioEndereco
{
    public class ObterUsuario_UsuarioEnderecoResponseModel
    {
        public Guid Id { get; set; }
        public ObterEnderecoResponseModel Endereco { get; set; }
    }
}
