using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cds.BusinessCustomer.Api.CustomerFeature.Exceptions
{
    /// <summary>
    /// NotFound Exception
    /// </summary>
    [Serializable]
    public class NotFoundException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public NotFoundException()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public NotFoundException(string s)
            : base(String.Format(s))
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
                { }
    }
}
