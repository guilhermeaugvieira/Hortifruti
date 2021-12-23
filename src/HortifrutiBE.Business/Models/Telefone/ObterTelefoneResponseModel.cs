using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifrutiBE.Business.Models.Telefone
{
    public class ObterTelefoneResponseModel
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }
        public bool WhatsApp { get; set; }
    }
}
