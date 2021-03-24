using Cds.BusinessCustomer.Api.CustomerFeature.ViewModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cds.BusinessCustomer.Tests.Bdd.Core
{
    public static class BusinessCustomerHelper
    {
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
            };

            return res;
        }

        public static SingleCustomerViewModel GetCustomerRequestFromResponse(HttpResponseMessage response)
        {
            var EmpResponse = response.Content.ReadAsStringAsync().Result;
            var consumerInfo = JsonConvert.DeserializeObject<SingleCustomerViewModel>(EmpResponse);

            return consumerInfo;
        }
    }
}
