using Cds.BusinessCustomer.Domain.CustomerAggregate;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Abstractions;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cds.BusinessCustomer.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class InMemoryCartegieApi : ICartegieApi
    {
        /// <summary>
        /// 
        /// </summary>
        public InMemoryCartegieApi() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="socialReason"></param>
        /// <param name="zipCode"></param>
        /// <returns></returns>       
        public Task<List<CustomerMultipleSearchDto>> GetInfosByCriteria(string socialReason, string zipCode)
        {
            if (socialReason == "1" && zipCode == "2")
            {
                return Task.FromResult(new List<CustomerMultipleSearchDto>());
            }
            
            List<CustomerMultipleSearchDto> list = new List<CustomerMultipleSearchDto>
            {
                new CustomerMultipleSearchDto{ Name = "Electroplanet", Adress = "Maarif", Id = "1254", SocialReason = "rs154"},
                new CustomerMultipleSearchDto{ Name = "Jumia", Adress = "Derb Omar", Id = "78945", SocialReason = "rs7864"}
            };
            return Task.FromResult(list);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<CustomerSingleSearchDto> GetInfosById(string id)
        {
            if (id == "fze486")
            {
                return Task.FromResult((CustomerSingleSearchDto) null);
            }
            CustomerSingleSearchDto res = new CustomerSingleSearchDto
            {
#pragma warning disable S1192 // String literals should not be duplicated
                Name = "UBER PARTNER SUPPORT FRANCE SAS",
#pragma warning restore S1192 // String literals should not be duplicated
                Siret = "81999478100022",
                NafCode = "8299Z",
                ZipCode = "33000",
                City = "UBER PARTNER SUPPORT FRANCE SAS",
                SocialReason = "UBER PARTNER SUPPORT FRANCE SAS",
                Phone = "+21268085321",
                Adress = "Maarif",
                Civility = "Marocaine"
            };

            return Task.FromResult(res);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siret"></param>
        /// <returns></returns>
        public Task<CustomerSingleSearchDto> GetInfosBySiret(string siret)
        {
            if(siret == "78945612345129")
            {
                return Task.FromResult((CustomerSingleSearchDto)null);
            }
            CustomerSingleSearchDto res = new CustomerSingleSearchDto
            {
                Name = "UBER PARTNER SUPPORT FRANCE SAS",
                Siret = "81999478100022",
                NafCode = "8299Z",
                ZipCode = "33000",
                City = "UBER PARTNER SUPPORT FRANCE SAS",
                SocialReason = "UBER PARTNER SUPPORT FRANCE SAS",
                Phone = "+21268085321",
                Adress = "Maarif",
                Civility = "Marocaine"
            };
            return Task.FromResult(res);
        }

    }
}
