using System;
using System.ComponentModel.DataAnnotations;

namespace HortifrutiBE.Business.Models.ItemEstoque
{
    public class AtualizarItemEstoqueRequestModel
    {
       
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Valor { get; set; }
    }
}