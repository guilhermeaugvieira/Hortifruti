using System;
using System.ComponentModel.DataAnnotations;

namespace HortifrutiBE.Business.Models.ItemEstoque
{
    public class AdicionarItemEstoqueRequestModel
    {        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Quantidade { get; set; }
    }
}