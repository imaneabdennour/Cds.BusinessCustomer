using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cds.BusinessCustomer.Api.CustomerFeature.Errors
{
    /// <summary>
    /// Error : Not Found
    /// </summary>
    public class NotFoundError
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonResult Result { get; set; }

        /// <summary>
        /// Constructing a NotFound Error with message
        /// </summary>
        /// <param name="message"></param>
        public NotFoundError(string message)
        {
            Result = new JsonResult(message)
            {
                StatusCode = StatusCodes.Status404NotFound,
                Value = new { message = message }
            };
        }
    }
}
