using HortifrutiBE.Business.Models.Telefone;
using HortifrutiBE.Business.Models.UsuarioEndereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifrutiBE.Business.Models.Usuario
{
    public class ObterUsuarioResponseModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid IdentityId { get; set; }
        public string CPF { get; set; }
        public IEnumerable<ObterUsuario_UsuarioEnderecoResponseModel> Enderecos { get; set; }
        public ObterTelefoneResponseModel Telefone { get; set; }
    }
}
