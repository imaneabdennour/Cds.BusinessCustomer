using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cds.BusinessCustomer.Api.CustomerFeature.Errors
{
    /// <summary>
    /// 
    /// </summary>
    public class BadRequestError
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonResult Result { get; set; }
        /// <summary>
        /// 
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
