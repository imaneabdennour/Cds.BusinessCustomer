using System.ComponentModel.DataAnnotations;

namespace Cds.BusinessCustomer.Api.CustomerFeature.ViewModels
{
    /// <summary>
    /// ViewModel for multiple customers
    /// Exposed when searching by multiple params
    /// </summary>
    public class MultipleCustomersViewModel
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MultipleCustomersViewModel() { }

        /// <summary>
        /// Id
        /// </summary>
        [Required]
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
        /// Social reason
        /// </summary>
        public string SocialReason { get; set; }

    }
}
