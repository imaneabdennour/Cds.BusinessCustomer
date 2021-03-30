using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Dtos;
using Cds.TestFormationDotnetcore.Infrastructure;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cds.BusinessCustomer.Infrastructure.CustomerRepository.Abstractions
{
    /// <summary>
    /// Interface for CartegieApi 
    /// </summary>
    public interface ICartegieApi
    {        
        /// <summary>
        /// Gets list of Customer information by criteria : social reason + zip code
        /// </summary>
        /// <param name="socialReason"></param>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        Task<List<CustomerMultipleSearchDto>> GetInfosByCriteria(string socialReason, string zipCode);

        /// <summary>
        /// Gets Customer information by criteria : id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CustomerSingleSearchDto> GetInfosById(string id);

        /// <summary>
        /// Gets Customer information by criteria : siret
        /// </summary>
        /// <param name="siret"></param>
        /// <returns></returns>
        Task<CustomerSingleSearchDto> GetInfosBySiret(string siret);
    }
}
