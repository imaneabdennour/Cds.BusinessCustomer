using Cds.BusinessCustomer.Api.CustomerFeature.ViewModels;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cds.BusinessCustomer.Tests.Bdd.Core
{
    public static class BusinessCustomerHelper
    {
        //                  *********  Making request to my API *********

        public async static Task<HttpResponseMessage> GetBusinessCustomers(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetAsync(new Uri(Hooks.WebHostUri, $"/business-customer-information/{id}")).ConfigureAwait(false);
            }
        }
        public async static Task<HttpResponseMessage> GetBusinessCustomersBySiret(string siret)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetAsync(new Uri(Hooks.WebHostUri, $"/business-customer-information?siret={siret}")).ConfigureAwait(false);
            }
        }

        public async static Task<HttpResponseMessage> GetBusinessCustomersByMultiple(string socialReason, string zipCode)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetAsync(new Uri(Hooks.WebHostUri, $"/business-customer-information?socialReason={socialReason}&zipCode={zipCode}")).ConfigureAwait(false);
            }
        }


        //                  *********  Converting from Table *********

        public static SingleCustomerViewModel GetCustomerRequestFromTable(Table table)
        {
            SingleCustomerViewModel res = new SingleCustomerViewModel
            {
                Name = table.Rows[0][1],
                Siret = table.Rows[1][1],
                NafCode = table.Rows[2][1],
                ZipCode = table.Rows[3][1],
                City = table.Rows[4][1],
                SocialReason = table.Rows[5][1],
                Phone = table.Rows[6][1],
                Adress = table.Rows[7][1],
                Civility = table.Rows[8][1]
            };

            return res;
        }

        public static List<MultipleCustomersViewModel> GetCustomersRequestFromTable(Table table)
        {
            var tableRead = new List<MultipleCustomersViewModel>();

            foreach (var item in table.Rows)
            {
                tableRead.Add(new MultipleCustomersViewModel 
                { 
                    Name = item["Name"], 
                    Adress = item["Adress"], 
                    Id = item["Id"], 
                    SocialReason = item["SocialReason"]
                });
            }

            return tableRead;
        }
        public static Task<CustomerSingleSearchDto> GetCustomerDtoFromTable(Table table)
        {
            return Task.FromResult(new CustomerSingleSearchDto
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

        //                  *********  Converting from HttpResponseMessage *********

        public static SingleCustomerViewModel GetCustomerRequestFromResponse(HttpResponseMessage response)
        {
            var EmpResponse = response.Content.ReadAsStringAsync().Result;
            var consumerInfo = JsonConvert.DeserializeObject<SingleCustomerViewModel>(EmpResponse);

            return consumerInfo;
        }

        public static List<MultipleCustomersViewModel> GetCustomersRequestFromResponse(HttpResponseMessage response)
        {
            var EmpResponse = response.Content.ReadAsStringAsync().Result;

            var customerObj = JObject.Parse(EmpResponse);
            var customerGuid = Convert.ToString(customerObj["items"]);  // extracts json array which contains my list from my json object

            var consumerInfo = JsonConvert.DeserializeObject<List<MultipleCustomersViewModel>>(customerGuid); 

            return consumerInfo;
        }
    }
}
