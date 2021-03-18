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
        /// <param name="message"></param>
        public BadRequestError((bool, string) message)
        {
            Result = new JsonResult(message)
            {
                StatusCode = StatusCodes.Status400BadRequest,  
                Value = new { code = "400", message = message.Item2 }
            };
        }
    }
}
