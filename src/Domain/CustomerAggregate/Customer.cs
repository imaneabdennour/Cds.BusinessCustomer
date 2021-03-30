using Cds.BusinessCustomer.Domain.CustomerAggregate;
using System.ComponentModel.DataAnnotations;

namespace Cds.BusinessCustomer.Domain.ItemAggregate
{
    /// <summary>
    /// Business Customer Model (Not exposed)
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Siret Required Length
        /// </summary>
        private const int SiretLength = Constants.SiretRequiredLength;

        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

            /// <summary>
            /// Name
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Adress
            /// </summary>
            public string Adress { get; set; }


            /// <summary>
            /// Siret
            /// </summary>
            [MaxLength(SiretLength), MinLength(SiretLength)]
            public string Siret { get; set; }

            /// <summary>
            /// Naf code
            /// </summary>
            public string NafCode { get; set; }

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
            public string Civility { get; set; }        // 1 : monsieur, 2 : madame
        }
    }
