using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HortifrutiBE.Business.Models.Base
{
    public class ErrorVM
    {
        [Required]
        public bool Success { get; set; }
        [Required]
        public IEnumerable<string> Errors { get; set; }

        public ErrorVM(IEnumerable<string> errors)
        {
            Success = false;
            Errors = errors;
        }
    }
}
