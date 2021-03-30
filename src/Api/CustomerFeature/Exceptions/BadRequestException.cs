using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Cds.BusinessCustomer.Api.CustomerFeature.Exceptions
{
    /// <summary>
    /// BadRequets Exception
    /// </summary>
    [Serializable]
    public class BadRequestException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public BadRequestException():base()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public BadRequestException(string message, Exception innerException): base(message, innerException) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected BadRequestException(SerializationInfo info, StreamingContext context)
       : base(info, context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public BadRequestException(string s)
            : base(s)
        {

        }
    }
}
