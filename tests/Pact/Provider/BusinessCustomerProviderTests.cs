using Cds.BusinessCustomer.Infrastructure;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Dtos;
using Cds.Foundation.Test;
using Cds.Foundation.Test.Pact.Provider;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using System.Net.Http;
using System.Net;
using System.Linq;

namespace Cds.BusinessCustomer.Tests.ProviderPact
{ 
    /// <summary>
    /// Defines the SellerClientInvoiceWorker provider tests
    /// </summary>
    public class BusinessCustomerProviderTests : BaseProviderTests<BusinesCustomerProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SellerClientInvoiceWorkerProviderTests"/> class
        /// </summary>
        /// <param name="output">The Xunit output</param>
        /// <param name="provider">The provider</param>
        public BusinessCustomerProviderTests(ITestOutputHelper output, BusinesCustomerProvider provider) : base(output, provider)
        {
            ProviderStates.Add("Get business customer information by Id - Success", async () => await MockBusinessCustomerApiResponseByIdSuccess().ConfigureAwait(false));
            ProviderStates.Add("Get business customer information by Id - Not found", async () => await MockBusinessCustomerApiResponseByIdNotFound().ConfigureAwait(false));

            ProviderStates.Add("Get business customer information by Siret - Success", async () => await MockBusinessCustomerApiResponseBySiretSuccess().ConfigureAwait(false));
            ProviderStates.Add("Get business customer information by Siret - Not found", async () => await MockBusinessCustomerApiResponseBySiretNotFound().ConfigureAwait(false));
            ProviderStates.Add("Get business customer information by Siret - Bad request", async () => await MockBusinessCustomerApiResponseBySiretBadRequest().ConfigureAwait(false));

            ProviderStates.Add("Get business customer information by SocialReason and ZipCode - Success", async () => await MockBusinessCustomerApiResponseBySocialReasonAndZipCodeSuccess().ConfigureAwait(false));
            ProviderStates.Add("Get business customer information by SocialReason and ZipCode - Not found", async () => await MockBusinessCustomerApiResponseBySocialReasonAndZipCodeNotFound().ConfigureAwait(false));
            ProviderStates.Add("Get business customer information by SocialReason and ZipCode - Bad request(Bad socialreason)", async () => await MockBusinessCustomerApiResponseByBadSocialReasonAndZipCodeBadRequest().ConfigureAwait(false));
            ProviderStates.Add("Get business customer information by SocialReason and ZipCode - Bad request(Bad zipcode)", async () => await MockBusinessCustomerApiResponseBySocialReasonAndBadZipCodeBadRequest().ConfigureAwait(false));
        }

#pragma warning disable S125
        [Fact]
        public Task Provider_SellerClientInvoiceWorker() => EnsureProviderHonoursPactAsync();
              

                // Id
        private static async Task MockBusinessCustomerApiResponseByIdSuccess()
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:22038/business-customer-information/123456")
            };                      
            HttpResponseMessage httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/SuccessResponseById.json").ConfigureAwait(false))
            };
            GlobalServiceHandler.AddResponseMap(httpRequest, httpResponse);
        }        
        private static async Task MockBusinessCustomerApiResponseByIdNotFound()
        {
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:22038/business-customer-information/fze486")
            };
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/get_customer_byId_NotFound.json").ConfigureAwait(false))
            };
            GlobalServiceHandler.AddResponseMap(httpRequest, httpResponse);
        }

                // Siret
        private static async Task MockBusinessCustomerApiResponseBySiretSuccess()
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:22038/business-customer-information?siret=12345678912345")
            };
            HttpResponseMessage httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/SuccessResponseById.json").ConfigureAwait(false))
            };
            GlobalServiceHandler.AddResponseMap(httpRequest, httpResponse);
        }
        private static async Task MockBusinessCustomerApiResponseBySiretNotFound()
        {
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:22038/business-customer-information?siret=78945612345129")
            };
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/get_customer_bySiret_NotFound.json").ConfigureAwait(false))
            };
            GlobalServiceHandler.AddResponseMap(httpRequest, httpResponse);
        }
        private static async Task MockBusinessCustomerApiResponseBySiretBadRequest()
        {
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:22038/business-customer-information?siret=123")
            };
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/get_customer_bySiret_BadRequest.json").ConfigureAwait(false))
            };
            GlobalServiceHandler.AddResponseMap(httpRequest, httpResponse);
        }



                // SocialReason and ZipCode
        private static async Task MockBusinessCustomerApiResponseBySocialReasonAndZipCodeSuccess()
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:22038/business-customer-information?socialReason=456&zipCode=30000")
            };
            HttpResponseMessage httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/SuccessResponseByMultiple.json").ConfigureAwait(false))
            };
            GlobalServiceHandler.AddResponseMap(httpRequest, httpResponse);
        }
        private static async Task MockBusinessCustomerApiResponseBySocialReasonAndZipCodeNotFound()
        {
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:22038/business-customer-information?socialReason=1&zipCode=2")
            };
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/get_customer_byMultiple_NotFound.json").ConfigureAwait(false))

            };
            GlobalServiceHandler.AddResponseMap(httpRequest, httpResponse);
        }
        private static async Task MockBusinessCustomerApiResponseBySocialReasonAndBadZipCodeBadRequest()
        {
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:22038/business-customer-information?socialReason=3000&zipCode=")
            };
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/get_customer_byMultiple_BadRequest.json").ConfigureAwait(false))
            };
            GlobalServiceHandler.AddResponseMap(httpRequest, httpResponse);
        }
        private static async Task MockBusinessCustomerApiResponseByBadSocialReasonAndZipCodeBadRequest()
        {
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:22038/business-customer-information?socialReason=&zipCode=30000")
            };
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/get_customer_byMultiple_BadRequest.json").ConfigureAwait(false))

            };
            GlobalServiceHandler.AddResponseMap(httpRequest, httpResponse);
        }

    }
}
