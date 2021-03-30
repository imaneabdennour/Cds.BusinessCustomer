using Cds.BusinessCustomer.Domain.CustomerAggregate;
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
        public async Task<CustomerSingleSearchDto> GetInfosById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new ArgumentNullException();

                CustomerSingleSearchDto consumerInfo = await IdSearch(id);
                if (consumerInfo == null)
                    throw new ArgumentNullException();

                return consumerInfo;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        /// <summary>
        /// Get customer infos by siret
        /// </summary>
        /// <param name="siret"></param>
        /// <returns>Customer info</returns>
        public async Task<CustomerSingleSearchDto> GetInfosBySiret(string siret)
        {
            try
            {
                if (string.IsNullOrEmpty(siret) || siret.Length != Constants.SiretRequiredLength)
                    throw new ArgumentNullException();

                CustomerSingleSearchDto consumerInfo = await SiretSearch(siret);
                if (consumerInfo == null)
                    throw new ArgumentNullException();

                return consumerInfo;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

            /// <summary>
            /// Get customers infos by social number and zipcode
            /// </summary>
            /// <param name="socialReason"></param>
            /// <param name="zipCode"></param>
            /// <returns>Customer info</returns>
        public async Task<List<CustomerMultipleSearchDto>> GetInfosByCriteria(string socialReason, string zipCode)
        {
            try
            {
                if (string.IsNullOrEmpty(zipCode) || string.IsNullOrEmpty(socialReason))
                    throw new ArgumentNullException();

                List<CustomerMultipleSearchDto> list = await MultipleSearch(socialReason, zipCode);
                if (list == null || list.Count == 0)
                    throw new ArgumentNullException();

                return list;
            }
            catch (ArgumentNullException)
            {
                return new List<CustomerMultipleSearchDto>();
            }
        }


                    /// Communication with API de cartégie  ///

        /// <summary>
        /// Method to handle Cartégie api - searching by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<CustomerSingleSearchDto> IdSearch(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new ArgumentNullException();

                CustomerSingleSearchDto ConsumerInfo = new CustomerSingleSearchDto();

                var client = _clientFactory.CreateClient();

                client.BaseAddress = _configuration.BaseUrl;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync(_configuration.ById);

                if (res.IsSuccessStatusCode)
                {
                    ConsumerInfo = await FromResponseToDto(res);
                    if (ConsumerInfo == null)
                        throw new ArgumentNullException();
                }

                return ConsumerInfo;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        /// <summary>
        /// Method to handle Cartégie api - searching by siret
        /// </summary>
        /// <param name="siret"></param>
        /// <returns></returns>
        private async Task<CustomerSingleSearchDto> SiretSearch(string siret)
        {
            try
            {
                if (string.IsNullOrEmpty(siret) || siret.Length != Constants.SiretRequiredLength)
                    throw new ArgumentNullException();

                CustomerSingleSearchDto ConsumerInfo = new CustomerSingleSearchDto();

                using (var client = _clientFactory.CreateClient())
                {
                    client.BaseAddress =_configuration.BaseUrl;

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage res = await client.GetAsync(_configuration.BySiret);

                    if (res.IsSuccessStatusCode)
                    {
                        ConsumerInfo = await FromResponseToDto(res);
                        if (ConsumerInfo == null)
                            throw new ArgumentNullException();

                    }
                }
                return ConsumerInfo;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        /// <summary>
        /// Method to handle Cartégie api - searching by social number and zip code
        /// </summary>
        /// <param name="socialReason"></param>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        private async Task<List<CustomerMultipleSearchDto>> MultipleSearch(string socialReason, string zipcode)
        {
            try
            {
                if (string.IsNullOrEmpty(zipcode) || string.IsNullOrEmpty(socialReason))
                    throw new ArgumentNullException();

                var consumerInfo = new List<CustomerMultipleSearchDto>();

                using (var client = _clientFactory.CreateClient())
                {
                    client.BaseAddress = _configuration.BaseUrl;

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage res = await client.GetAsync(_configuration.ByMultiple);

                    if (res.IsSuccessStatusCode)
                    {
                        var EmpResponse = await res.Content.ReadAsStringAsync();
                        if (EmpResponse == null)
                        {
                            throw new ArgumentNullException();
                        }
                        consumerInfo = JsonConvert.DeserializeObject<List<CustomerMultipleSearchDto>>(EmpResponse);
                    }
                }

                return consumerInfo;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }


        /// <summary>
        /// Converting HttpResponseMessage to DTO
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        private static async Task<CustomerSingleSearchDto> FromResponseToDto(HttpResponseMessage res)
        {
            if (res == null)
                return null;

            var EmpResponse = await res.Content.ReadAsStringAsync();
            if (EmpResponse == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<CustomerSingleSearchDto>(EmpResponse.Substring(1, EmpResponse.Length - 2));
        }
       
    }
}
