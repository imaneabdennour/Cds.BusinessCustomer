using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cds.BusinessCustomer.Api.CustomerFeature.Exceptions
{
    /// <summary>
    /// BadRequets Exception
    /// </summary>
    public class BadRequestException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public BadRequestException()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public BadRequestException(string s)
            : base(String.Format(s))
        {

        }
    }
}
