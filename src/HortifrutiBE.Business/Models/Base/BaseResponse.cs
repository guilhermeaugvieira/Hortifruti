using Microsoft.AspNetCore.Mvc;

namespace HortifrutiBE.Business.Models.Base
{
    public class BaseResponse<TResult> : ActionResult
    {
        public BaseResponse(dynamic objetoResultado)
        {
            
        }
    }
}