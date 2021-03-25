using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Abstractions;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cds.BusinessCustomer.Tests.Bdd.Core
{
    public class InMemoryCartegieApi : ICartegieApi
    {
        public InMemoryCartegieApi() { }
        public Task<List<CustomerMultipleSearchDTO>> GetInfosByCriteria(string socialReason, string zipCode)
        {
            return Task.FromResult(new List<CustomerMultipleSearchDTO>()
            {
                new CustomerMultipleSearchDTO {
                    Name = "Electroplanet",
                    Adress = "Maarif",
                    Id = "1254",
                    SocialReason = "rs154"
                },
                new CustomerMultipleSearchDTO {
                    Name = "Jumia",
                    Adress = "Derb Omar",
                    Id = "78945",
                    SocialReason = "rs184"
                }
            });
        }

        public Task<CustomerSingleSearchDTO> GetInfosById(string id)
        {
            return Task.FromResult(new CustomerSingleSearchDTO()
            {
                Name = "UBER PARTNER SUPPORT FRANCE SAS",
                Adress = "Maarif",
                Civility = "Marocaine",
                NafCode = "35678899",
                Phone = "+21268085321",
                Siret = "81999478100022",
                SocialReason = "rs456",
                ZipCode = "20100"
            });
        }

        public Task<CustomerSingleSearchDTO> GetInfosBySiret(string siret)
        {
            return Task.FromResult(new CustomerSingleSearchDTO()
            {
                Name = "UBER PARTNER SUPPORT FRANCE SAS",
                Adress = "Maarif",
                Civility = "Marocaine",
                NafCode = "35678899",
                Phone = "+21268085321",
                Siret = "81999478100022",
                SocialReason = "rs456",
                ZipCode = "20100"
            });
        }

    }
}
