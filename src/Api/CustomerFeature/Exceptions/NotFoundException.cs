using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cds.BusinessCustomer.Api.CustomerFeature.Exceptions
{
    /// <summary>
    /// NotFound Exception
    /// </summary>
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
    }
}
