using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cds.BusinessCustomer.Api.CustomerFeature.Errors
{
    /// <summary>
    /// Error : BadRequest
    /// </summary>
    public class BadRequestError
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonResult Result { get; set; }
        /// <summary>
        /// Constructing a BadRequest Error with message
        /// </summary>
        /// <param name="msg"></param>
        public BadRequestError(string msg)
        {
            Result = new JsonResult(msg)
            {
                StatusCode = StatusCodes.Status400BadRequest,  
                Value = new { code = "400", message = msg }
            };
        }
    }
}
