using System;
using System.Collections.Generic;
using System.Text;

namespace Cds.TestFormationDotnetcore.Infrastructure
{
    /// <summary>
    /// Configuration POCO
    /// </summary>
    public class CartegieConfiguration
    {
        /// <summary>
        /// Base url for cartegie api
        /// </summary>
        public Uri BaseUrl { get; set; }

        /// <summary>
        /// Cartegie api's key
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Research by Siret
        /// </summary>
        public Uri BySiret { get; set; }

        /// <summary>
        /// Research by multiple params
        /// </summary>
        public Uri ByMultiple { get; set; }

        /// <summary>
        /// Research by Siret
        /// </summary>
        public Uri ById { get; set; }


    }
}
