using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cds.BusinessCustomer.Api.CustomerFeature.ViewModels
{
    /// <summary>
    /// ViewModel for single customer
    /// Exposed when searching by single param
    /// </summary>
    public class SingleCustomerViewModel : ViewModel
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public SingleCustomerViewModel() { }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Siret
        /// </summary>
        [MaxLength(14), MinLength(14)]
        public string Siret { get; set; }

        /// <summary>
        /// Naf code
        /// </summary>
        public string NafCode { get; set; }

        /// <summary>
        /// Adress
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// Phone Number
        /// </summary>       
        public string Phone { get; set; }

        /// <summary>
        /// Zip Code
        /// </summary>      
        public string ZipCode { get; set; }

        /// <summary>
        /// City
        /// </summary>      
        public string City { get; set; }

        /// <summary>
        /// Social Reason
        /// </summary>
        public string SocialReason { get; set; }

        /// <summary>
        /// Civility 
        /// </summary>
        public string Civility { get; set; }

    }
}
