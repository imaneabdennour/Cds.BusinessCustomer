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
            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new ArgumentNullException();

                CustomerSingleSearchDTO consumerInfo = IdSearch(id).Result;
                if (consumerInfo == null)
                    throw new ArgumentNullException();
                
                return Task.FromResult(consumerInfo);
            }
            catch (ArgumentNullException)
            {
                return Task.FromResult<CustomerSingleSearchDTO>(null);
            }
        }

        /// <summary>
        /// Get customer infos by siret
        /// </summary>
        /// <param name="siret"></param>
        /// <returns>Customer info</returns>
        public Task<CustomerSingleSearchDTO> GetInfosBySiret(string siret)
        {
            try
            {
                if (string.IsNullOrEmpty(siret) || siret.Length != 14)
                    throw new ArgumentNullException();

                CustomerSingleSearchDTO consumerInfo = SiretSearch(siret).Result;
                if (consumerInfo == null)
                    throw new ArgumentNullException();

                return Task.FromResult(consumerInfo);
            }
            catch (ArgumentNullException)
            {
                return Task.FromResult<CustomerSingleSearchDTO>(null);
            }
        }

            /// <summary>
            /// Get customers infos by social number and zipcode
            /// </summary>
            /// <param name="socialReason"></param>
            /// <param name="zipCode"></param>
            /// <returns>Customer info</returns>
        public Task<List<CustomerMultipleSearchDTO>> GetInfosByCriteria(string socialReason, string zipCode)
        {
            try
            {
                if (string.IsNullOrEmpty(zipCode) || string.IsNullOrEmpty(socialReason))
                    throw new ArgumentNullException();

                List<CustomerMultipleSearchDTO> list = MultipleSearch(socialReason, zipCode).Result;
                if (list == null || list.Count == 0)
                    throw new ArgumentNullException();
                
                return Task.FromResult(list);
            }
            catch (ArgumentNullException)
            {
                return Task.FromResult<List<CustomerMultipleSearchDTO>>(null);
            }
        }


                    /// Communication with API de cartégie  ///

        /// <summary>
        /// Method to handle Cartégie api - searching by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<CustomerSingleSearchDTO> IdSearch(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new ArgumentNullException();

                CustomerSingleSearchDTO ConsumerInfo = new CustomerSingleSearchDTO();

                var client = _clientFactory.CreateClient();

                client.BaseAddress = new Uri(_configuration.BaseUrl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync(_configuration.ById);

                if (res.IsSuccessStatusCode)
                {
                    ConsumerInfo = FromResponseToDto(res);
                    if (ConsumerInfo == null)
                        throw new ArgumentNullException();
                }

                return ConsumerInfo;
            }
            catch (ArgumentNullException)
            {
                return await Task.FromResult<CustomerSingleSearchDTO>(null);
            }
        }

        /// <summary>
        /// Method to handle Cartégie api - searching by siret
        /// </summary>
        /// <param name="siret"></param>
        /// <returns></returns>
        private async Task<CustomerSingleSearchDTO> SiretSearch(string siret)
        {
            try
            {
                if (string.IsNullOrEmpty(siret) || siret.Length != 14)
                    throw new ArgumentNullException();

                CustomerSingleSearchDTO ConsumerInfo = new CustomerSingleSearchDTO();

                using (var client = _clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(_configuration.BaseUrl);

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage res = await client.GetAsync(_configuration.BySiret);

                    if (res.IsSuccessStatusCode)
                    {
                        ConsumerInfo = FromResponseToDto(res);
                        if (ConsumerInfo == null)
                            throw new ArgumentNullException();

                    }
                }
                return ConsumerInfo;
            }
            catch (ArgumentNullException)
            {
                return await Task.FromResult<CustomerSingleSearchDTO>(null);
            }
        }

        /// <summary>
        /// Method to handle Cartégie api - searching by social number and zip code
        /// </summary>
        /// <param name="socialReason"></param>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        private async Task<List<CustomerMultipleSearchDTO>> MultipleSearch(string socialReason, string zipcode)
        {
            try
            {
                if (string.IsNullOrEmpty(zipcode) || string.IsNullOrEmpty(socialReason))
                    throw new ArgumentNullException();

                var consumerInfo = new List<CustomerMultipleSearchDTO>();

                using (var client = _clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(_configuration.BaseUrl);

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage res = await client.GetAsync(_configuration.ByMultiple);

                    if (res.IsSuccessStatusCode)
                    {
                        var EmpResponse = res.Content.ReadAsStringAsync().Result;
                        if (EmpResponse == null)
                        {
                            throw new ArgumentNullException();
                        }
                        consumerInfo = JsonConvert.DeserializeObject<List<CustomerMultipleSearchDTO>>(EmpResponse);
                    }
                }

                return consumerInfo;
            }
            catch (ArgumentNullException)
            {
                return await Task.FromResult<List<CustomerMultipleSearchDTO>>(null);
            }
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

            var EmpResponse = res.Content.ReadAsStringAsync().Result;
            if (EmpResponse == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<CustomerSingleSearchDTO>(EmpResponse.Substring(1, EmpResponse.Length - 2));
        }
       
    }
}
