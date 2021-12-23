using System.ComponentModel.DataAnnotations;

namespace HortifrutiBE.Business.Models.Base
{
    public class SuccessVM<TData>
    {
        [Required]
        public bool Success { get; private set; }

        [Required]
        public TData Data { get; private set; }

        public SuccessVM(TData data)
        {
            Success = true;
            Data = data;
        }
    }
}
