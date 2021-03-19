using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Abstractions;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Cds.TestFormationDotnetcore.Infrastructure
{
    /// <summary>
    /// Cartegie API
    /// </summary>
    public class CartegieApi : ICartegieApi
    {
        private readonly IHttpClientFactory _clientFactory;
        private CartegieConfiguration _configuration;
        /// <summary>
        /// Cartagie Api cstr
        /// </summary>
        /// <param name="myConfiguration"></param>
        /// <param name="clientFactory"></param>
        public CartegieApi(CartegieConfiguration myConfiguration, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _configuration = myConfiguration;

        }
        /// <summary>
        /// Get customer infos by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Customer info</returns>
        public Task<CustomerSingleSearchDTO> GetInfosById(string id)
        {
            if (IsNullOrEmpty(id))
                return Task.FromResult<CustomerSingleSearchDTO>(null);

            CustomerSingleSearchDTO consumerInfo = IdSearch(id).Result;
            if (consumerInfo == null)
            {
                return Task.FromResult<CustomerSingleSearchDTO>(null);
            }
            return Task.FromResult(consumerInfo);
        }

        /// <summary>
        /// Get customer infos by siret
        /// </summary>
        /// <param name="siret"></param>
        /// <returns>Customer info</returns>
        public Task<CustomerSingleSearchDTO> GetInfosBySiret(string siret)
        {
            if (IsNullOrEmpty(siret) || siret.Length != 14)
                return Task.FromResult<CustomerSingleSearchDTO>(null);

            CustomerSingleSearchDTO consumerInfo = SiretSearch(siret).Result;
            return Task.FromResult(consumerInfo);
        }

        /// <summary>
        /// Get customers infos by social number and zipcode
        /// </summary>
        /// <param name="socialReason"></param>
        /// <param name="zipCode"></param>
        /// <returns>Customer info</returns>
        public Task<List<CustomerMultipleSearchDTO>> GetInfosByCriteria(string socialReason, string zipCode)
        {
            if (IsNullOrEmpty(zipCode) || IsNullOrEmpty(socialReason))
                return Task.FromResult<List<CustomerMultipleSearchDTO>>(null);
            List<CustomerMultipleSearchDTO> list = MultipleSearch(socialReason, zipCode).Result;
            if (list == null || list.Count == 0)
            {
                return Task.FromResult<List<CustomerMultipleSearchDTO>>(null);
            }
            return Task.FromResult(list);
        }


                    /// Communication with API de cartégie  ///

        /// <summary>
        /// Method to handle Cartégie api - searching by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<CustomerSingleSearchDTO> IdSearch(string id)
        {
            if (IsNullOrEmpty(id))
                return await Task.FromResult<CustomerSingleSearchDTO>(null);

            CustomerSingleSearchDTO ConsumerInfo = new CustomerSingleSearchDTO();

            var client = _clientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration.BaseUrl);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // status code and data :
            HttpResponseMessage res = await client.GetAsync(_configuration.ById);

            if (res.IsSuccessStatusCode)
            {
                ConsumerInfo = FromResponseToDto(res);
                if (ConsumerInfo == null)
                    return await Task.FromResult<CustomerSingleSearchDTO>(null);
            }

            return ConsumerInfo;
        }

        /// <summary>
        /// Method to handle Cartégie api - searching by siret
        /// </summary>
        /// <param name="siret"></param>
        /// <returns></returns>
        private async Task<CustomerSingleSearchDTO> SiretSearch(string siret)
        {
            if (IsNullOrEmpty(siret) || siret.Length != 14)
                return await Task.FromResult<CustomerSingleSearchDTO>(null);

            CustomerSingleSearchDTO ConsumerInfo = new CustomerSingleSearchDTO();

            using (var client = _clientFactory.CreateClient())
            {
                client.BaseAddress = new Uri(_configuration.BaseUrl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // status code and data :
                HttpResponseMessage res = await client.GetAsync(_configuration.BySiret);

                if (res.IsSuccessStatusCode)
                {
                    ConsumerInfo = FromResponseToDto(res);
                    if (ConsumerInfo == null)
                        return await Task.FromResult<CustomerSingleSearchDTO>(null);
                }
            }
            return ConsumerInfo;
        }

        /// <summary>
        /// Method to handle Cartégie api - searching by social number and zip code
        /// </summary>
        /// <param name="socialReason"></param>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        private async Task<List<CustomerMultipleSearchDTO>> MultipleSearch(string socialReason, string zipcode)
        {
            if (IsNullOrEmpty(socialReason) || IsNullOrEmpty(zipcode))
                return await Task.FromResult<List<CustomerMultipleSearchDTO>>(null);

            var consumerInfo = new List<CustomerMultipleSearchDTO>();

            using (var client = _clientFactory.CreateClient())
            {
                client.BaseAddress = new Uri(_configuration.BaseUrl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // status code and data :
                HttpResponseMessage res = await client.GetAsync(_configuration.ByMultiple);

                if (res.IsSuccessStatusCode)
                {
                    // Storing the response details recieved from web api   
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    if (EmpResponse == null)
                    {
                        return await Task.FromResult<List<CustomerMultipleSearchDTO>>(null);
                    }
                    // Deserializing the response recieved from web api and storing it
                    consumerInfo = JsonConvert.DeserializeObject<List<CustomerMultipleSearchDTO>>(EmpResponse);
                }
            }

            return consumerInfo;
        }


        /// <summary>
        /// Converting HttpResponseMessage to DTO
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        private CustomerSingleSearchDTO FromResponseToDto(HttpResponseMessage res)
        {
            if (res == null)
                return null;
            // Storing the response details received from web api   
            var EmpResponse = res.Content.ReadAsStringAsync().Result;
            if (EmpResponse == null)
            {
                return null;
            }
            // Deserializing the response received from web api and storing it  
            return JsonConvert.DeserializeObject<CustomerSingleSearchDTO>(EmpResponse.Substring(1, EmpResponse.Length - 2));
        }

        private static bool IsNullOrEmpty(string s)
        {
            if (s == null || s == "")
                return true;
            return false;
        }
    }
}
