using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cds.BusinessCustomer.Api.CustomerFeature.Errors
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiError
    {
        /// <summary>
        /// 
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Constructr 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        public ApiError(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }
    }
}
