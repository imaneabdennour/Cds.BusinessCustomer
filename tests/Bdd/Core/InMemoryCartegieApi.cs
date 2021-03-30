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

        public Task<List<CustomerMultipleSearchDto>> GetInfosByCriteria(string socialReason, string zipCode)
        {
            if(Table.Rows.Count == 0)
                return Task.FromResult<List<CustomerMultipleSearchDto>>(null);

            var tableRead = new List<CustomerMultipleSearchDto>();
            foreach (var item in Table.Rows)
            {
                tableRead.Add(new CustomerMultipleSearchDto
                {
                    Name = item["Name"],
                    Adress = item["Adress"],
                    Id = item["Id"],
                    SocialReason = item["SocialReason"]
                });
            }
            return Task.FromResult(tableRead);
        }

        public Task<CustomerSingleSearchDto> GetInfosById(string id)
        {
            if (Table.Rows.Count == 0)
                return Task.FromResult<CustomerSingleSearchDto>(null);

            return Task.FromResult(new CustomerSingleSearchDto()
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

        public Task<CustomerSingleSearchDto> GetInfosBySiret(string siret)
        {
            if (Table.Rows.Count == 0)
                return Task.FromResult<CustomerSingleSearchDto>(null);

            return Task.FromResult(new CustomerSingleSearchDto()
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
