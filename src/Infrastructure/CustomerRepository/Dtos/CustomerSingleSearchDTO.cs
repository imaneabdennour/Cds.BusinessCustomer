using Cds.BusinessCustomer.Domain.CustomerAggregate;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Cds.BusinessCustomer.Infrastructure.CustomerRepository.Dtos
{
    /// <summary>
    /// Solution to not expose my Customer objects 
    /// Exposed when searching by single param
    /// </summary>
    public class CustomerSingleSearchDto
    {
        /// <summary>
        /// Siret Required Length
        /// </summary>
        private const int SiretLength = Constants.SiretRequiredLength;

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty("adresse1")]
        public string Name { get; set; }

        /// <summary>
        /// Siret
        /// </summary>
        [JsonProperty("siret")]
        [MaxLength(SiretLength), MinLength(SiretLength)]
        public string Siret { get; set; }

        /// <summary>
        /// Naf code
        /// </summary>
        [JsonProperty("apen700")]
        public string NafCode { get; set; }

        /// <summary>
        /// Adress
        /// </summary>
        [JsonProperty("adresse4")]
        public string Adress { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        [JsonProperty("codpos")]
        public string ZipCode { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [JsonProperty("lib_commune")]
        public string City { get; set; }

        /// <summary>
        /// Social reason
        /// </summary>
        [JsonProperty("rs")]
        public string SocialReason { get; set; }

        /// <summary>
        /// Civility
        /// </summary>
        [JsonProperty("civilite")]
        public string Civility { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [JsonProperty("tel")]
        public string Phone { get; set; }

    }
}
