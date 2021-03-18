using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cds.BusinessCustomer.Api.CustomerFeature.Validation
{
    /// <summary>
    /// Class for parameters validation
    /// </summary>
    public class ParametersHandler : IParametersHandler
    {
        private readonly ILogger<ParametersHandler> _logger;

        /// <summary>
        /// ParametersHandler constructor
        /// </summary>
        /// <param name="logger"></param>
        public ParametersHandler(ILogger<ParametersHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Validation for parameter : siret - should be of length 14
        /// </summary>
        /// <param name="siret"></param>
        /// <returns></returns>
        public (bool, string) Validate(string siret)
        {
            if (siret.Length != 14)
            {
                _logger.LogError($"Failed to retreive customer with siret = {siret}, Siret string should be of length 14");

                return (false, "Invalid Siret - should be of length 14");
            }
            return (true, null);
        }

        /// <summary>
        /// Validation for parameters : socialreason and zipcode
        /// </summary>
        /// <param name="socialreason"></param>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        public (bool, string) Validate(string socialreason, string zipcode)
        {
            if (IsNullOrEmpty(socialreason) && IsNullOrEmpty(zipcode))
            {
                _logger.LogError("Failed to retreive customers - You should specify Siret OR SocialReason and ZipCode");
                return (false, "You should enter Siret OR SocialReason and ZipCode");
            }
            if (IsNullOrEmpty(socialreason) || IsNullOrEmpty(zipcode))
            {
                _logger.LogError("Failed to retreive customers - You should specify both SocialReason and ZipCode");
                return (false, "You should enter both SocialReason and ZipCode");
            }
            return (true, null);
        }
        private static bool IsNullOrEmpty(string s)
        {
            if(s == null || s == "")
                return true;
            return false;
        }
    }
}
