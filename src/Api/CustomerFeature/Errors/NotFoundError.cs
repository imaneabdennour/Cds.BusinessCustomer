using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cds.BusinessCustomer.Api.CustomerFeature.Errors
{
    /// <summary>
    /// 
    /// </summary>
    public class NotFoundError
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonResult Result { get; set; }
        /// <summary>
        /// 
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
