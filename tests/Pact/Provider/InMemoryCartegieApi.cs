using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Abstractions;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cds.BusinessCustomer.Tests.ProviderPact
{
    public class InMemoryCartegieApi : ICartegieApi
    {
        public Task<List<CustomerMultipleSearchDto>> GetInfosByCriteria(string socialReason, string zipCode)
        {
            throw new System.NotImplementedException();
        }

        public Task<CustomerSingleSearchDto> GetInfosById(string id)
        {
            CustomerSingleSearchDto customer = new CustomerSingleSearchDto
            {
                Name = "UBER PARTNER SUPPORT FRANCE SAS",
                Siret = "81999478100022",
                NafCode = "8299Z",
                Adress = "",
                Phone = null,
                ZipCode = "33000",
                City = "UBER PARTNER SUPPORT FRANCE SAS",
                SocialReason = "UBER PARTNER SUPPORT FRANCE SAS",
                Civility = null
            };
            return Task.FromResult(customer) ;
        }

        public Task<CustomerSingleSearchDto> GetInfosBySiret(string siret)
        {
            throw new System.NotImplementedException();
        }
    }
}
