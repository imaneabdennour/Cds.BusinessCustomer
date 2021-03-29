using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Abstractions;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cds.BusinessCustomer.Tests.Bdd.Core
{
    public class InMemoryCartegieApi : ICartegieApi
    {
        public static Table Table { get; set; }
        
        public InMemoryCartegieApi() { }
        public InMemoryCartegieApi(Table table) {
            Table = table;
        }

        public Task<List<CustomerMultipleSearchDTO>> GetInfosByCriteria(string socialReason, string zipCode)
        {
            if(Table.Rows.Count == 0)
                return Task.FromResult<List<CustomerMultipleSearchDTO>>(null);

            var tableRead = new List<CustomerMultipleSearchDTO>();
            foreach (var item in Table.Rows)
            {
                tableRead.Add(new CustomerMultipleSearchDTO
                {
                    Name = item["Name"],
                    Adress = item["Adress"],
                    Id = item["Id"],
                    SocialReason = item["SocialReason"]
                });
            }
            return Task.FromResult(tableRead);
        }

        public Task<CustomerSingleSearchDTO> GetInfosById(string id)
        {
            if (Table.Rows.Count == 0)
                return Task.FromResult<CustomerSingleSearchDTO>(null);

            return Task.FromResult(new CustomerSingleSearchDTO()
            {
                Name = Table.Rows[0][1],
                Siret = Table.Rows[1][1],
                NafCode = Table.Rows[2][1],
                ZipCode = Table.Rows[3][1],
                City = Table.Rows[4][1],
                SocialReason = Table.Rows[5][1],
                Phone = Table.Rows[6][1],
                Adress = Table.Rows[7][1],
                Civility = Table.Rows[8][1]
            });
        }

        public Task<CustomerSingleSearchDTO> GetInfosBySiret(string siret)
        {
            if (Table.Rows.Count == 0)
                return Task.FromResult<CustomerSingleSearchDTO>(null);

            return Task.FromResult(new CustomerSingleSearchDTO()
            {
                Name = Table.Rows[0][1],
                Siret = Table.Rows[1][1],
                NafCode = Table.Rows[2][1],
                ZipCode = Table.Rows[3][1],
                City = Table.Rows[4][1],
                SocialReason = Table.Rows[5][1],
                Phone = Table.Rows[6][1],
                Adress = Table.Rows[7][1],
                Civility = Table.Rows[8][1]
            });
        }

    }
}
