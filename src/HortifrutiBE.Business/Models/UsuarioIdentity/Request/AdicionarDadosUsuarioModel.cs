using HortifrutiBE.Business.Models.Telefone;
using System;
using System.ComponentModel.DataAnnotations;

namespace HortifrutiBE.Business.Models.Usuario.Request
{
    public class AdicionarDadosUsuarioModel
    {
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Sobrenome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(11)]
        public string CPF { get; set; }

        [Required]
        public AdicionarTelefoneRequestModel Telefone { get; set; }
    }
}
