using Cds.Foundation.Test;
using Cds.Foundation.Test.Pact.Consumer;
using Newtonsoft.Json;
using PactNet.Matchers;
using PactNet.Mocks.MockHttpService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cds.BusinessCustomer.Tests.ConsumerPact
{
    public class BusinessCustomerConsumerTests : BaseConsumerTests<BusinessCustomerConsumer>
    {
        public BusinessCustomerConsumerTests(BusinessCustomerConsumer consumer) : base(consumer) { }

                // Id
        [Fact]
        public async Task BusinessCustomerConsumer_GetById_Return200OKWithInformation()
        {
            string customerId = "123456";
            var request = new ProviderServiceRequest
            {
                Method = HttpVerb.Get,
                Path = $"/business-customer-information/{customerId}"
            };

            var responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/get_customer_body_success.json").ConfigureAwait(false));
            var response = new ProviderServiceResponse
            {
                Status = 200,
                Headers = new Dictionary<string, object>
                {
                    { "Content-Type", "application/vnd.restful+json; charset=utf-8" }
                },
                Body = Match.Type(responseBody)                
            };

            MockProviderService.Given("Get business customer information by Id - Success")
                .UponReceiving("Valid Id")
                .With(request)
                .WillRespondWith(response);

            HttpResponseMessage httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, $"/business-customer-information/{customerId}")).ConfigureAwait(false);
            object content = JsonConvert.DeserializeObject(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.Equal(responseBody, content);
            MockProviderService.VerifyInteractions();

        }

        [Fact]
        public async Task BusinessCustomerConsumer_GetById_Return404NOTFOUNDWithoutInformation()
        {
            string customerId = "fze486";
            var request = new ProviderServiceRequest
            {
                Method = HttpVerb.Get,
                Path = $"/business-customer-information/{customerId}"
            };

            var responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/get_customer_byId_NotFound.json").ConfigureAwait(false));
            var response = new ProviderServiceResponse
            {
                Status = 404,
                Headers = new Dictionary<string, object>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                },
                Body = Match.Type(responseBody)
            };

            MockProviderService.Given("Get business customer information by Id - Not found")
                .UponReceiving("Not existing Id")
                .With(request)
                .WillRespondWith(response);

            HttpResponseMessage httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, $"/business-customer-information/{customerId}")).ConfigureAwait(false);
            object content = JsonConvert.DeserializeObject(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);
            Assert.Equal(responseBody, content);
            MockProviderService.VerifyInteractions();

        }

        // Siret
        [Fact]
        public async Task BusinessCustomerConsumer_GetBySiret_Return200OKWithInformation()
        {
            string customerSiret = "12345678912345";
            var request = new ProviderServiceRequest
            {
                Method = HttpVerb.Get,
                Path = $"/business-customer-information",
                Query = new Dictionary<string, string>
                {
                    { "siret", customerSiret}
                }
            };

            var responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/get_customer_body_success.json").ConfigureAwait(false));
            var response = new ProviderServiceResponse
            {
                Status = 200,
                Headers = new Dictionary<string, object>
                {
                    { "Content-Type", "application/vnd.restful+json; charset=utf-8" }
                },
                Body = Match.Type(responseBody)
            };

            MockProviderService.Given("Get business customer information by Siret - Success")
                .UponReceiving("Valid Siret")
                .With(request)
                .WillRespondWith(response);

            HttpResponseMessage httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, $"/business-customer-information?siret={customerSiret}")).ConfigureAwait(false);
            object content = JsonConvert.DeserializeObject(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.Equal(responseBody, content);
            MockProviderService.VerifyInteractions();
        }

        [Fact]
        public async Task BusinessCustomerConsumer_GetSiret_Return400BADREQUESTWithoutInformation()
        {
            string customerSiret = "123";
            var request = new ProviderServiceRequest
            {
                Method = HttpVerb.Get,
                Path = $"/business-customer-information",
                Query = new Dictionary<string, string>
                {
                    { "siret", customerSiret}
                }
            };
            var responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/get_customer_bySiret_BadRequest.json").ConfigureAwait(false));
            var response = new ProviderServiceResponse
            {
                Status = 400,
                Headers = new Dictionary<string, object>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                },
                Body = Match.Type(responseBody)
            };
            MockProviderService.Given("Get business customer information by Siret - Bad request")
                .UponReceiving("Invalid Siret")
                .With(request)
                .WillRespondWith(response);

            HttpResponseMessage httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, $"/business-customer-information?siret={customerSiret}")).ConfigureAwait(false);
            object content = JsonConvert.DeserializeObject(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            Assert.Equal(HttpStatusCode.BadRequest, httpResponse.StatusCode);
            Assert.Equal(responseBody, content);
            MockProviderService.VerifyInteractions();
        }

        [Fact]
        public async Task BusinessCustomerConsumer_GetSiret_Return404NOTFOUNDWithoutInformation()
        {
            string customerSiret = "78945612345129";
            var request = new ProviderServiceRequest
            {
                Method = HttpVerb.Get,
                Path = $"/business-customer-information",
                Query = new Dictionary<string, string>
                {
                    { "siret", customerSiret}
                }
            };
            var responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/get_customer_bySiret_NotFound.json").ConfigureAwait(false));
            var response = new ProviderServiceResponse
            {
                Status = 404,
                Headers = new Dictionary<string, object>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                },
                Body = Match.Type(responseBody)
            };
            MockProviderService.Given("Get business customer information by Siret - Not found")
                .UponReceiving("Not existing Siret")
                .With(request)
                .WillRespondWith(response);

            HttpResponseMessage httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, $"/business-customer-information?siret={customerSiret}")).ConfigureAwait(false);
            object content = JsonConvert.DeserializeObject(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);
            Assert.Equal(responseBody, content);
            MockProviderService.VerifyInteractions();
        }

        //SocialReason and ZipCode  
        [Fact]
        public async Task BusinessCustomerConsumer_GetBySocialReasonAndZipCode_Return200OKWithInformation()
        {
            string socialReason = "456";
            string zipCode = "30000";
            var request = new ProviderServiceRequest
            {
                Method = HttpVerb.Get,
                Path = $"/business-customer-information",
                Query = new Dictionary<string, string>
                {
                    { "socialReason", socialReason},
                    { "zipCode", zipCode}
                }
            };

            var responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/get_customers_body_success.json").ConfigureAwait(false));
            var response = new ProviderServiceResponse
            {
                Status = 200,
                Headers = new Dictionary<string, object>
                {
                    { "Content-Type", "application/vnd.restful+json; charset=utf-8" }
                },
                Body = Match.Type(responseBody)
            };

            MockProviderService.Given("Get business customer information by SocialReason and ZipCode - Success")
                .UponReceiving("Valid SocialReason and ZipCode")
                .With(request)
                .WillRespondWith(response);

            HttpResponseMessage httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, $"/business-customer-information?socialReason={socialReason}&zipCode={zipCode}")).ConfigureAwait(false);
            object content = JsonConvert.DeserializeObject(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.Equal(responseBody, content);
            MockProviderService.VerifyInteractions();
        }

        [Fact]
        public async Task BusinessCustomerConsumer_GetByInvalidSocialReasonAndZipCode_Return400BADREQUESTWithoutInformation()
        {
            string socialReason = "";
            string zipCode = "30000";
            var request = new ProviderServiceRequest
            {
                Method = HttpVerb.Get,
                Path = $"/business-customer-information",
                Query = new Dictionary<string, string>
                {
                    { "socialReason", socialReason},
                    { "zipCode", zipCode}
                }
            };

            var responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/get_customer_bySiret_BadRequest.json").ConfigureAwait(false));
            var response = new ProviderServiceResponse
            {
                Status = 400,
                Headers = new Dictionary<string, object>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                },
                Body = Match.Type(responseBody)
            };

            MockProviderService.Given("Get business customer information by SocialReason and ZipCode - Bad request(Bad socialreason)")
                .UponReceiving("Invalid SocialReason and valid ZipCode")
                .With(request)
                .WillRespondWith(response);

            HttpResponseMessage httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, $"/business-customer-information?socialReason={socialReason}&zipCode={zipCode}")).ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.BadRequest, httpResponse.StatusCode);
            MockProviderService.VerifyInteractions();
        }

        [Fact]
        public async Task BusinessCustomerConsumer_GetBySocialReasonAndInvalidZipCode_Return400BADREQUESTWithoutInformation()
        {
            string socialReason = "3000";
            string zipCode = "";
            var request = new ProviderServiceRequest
            {
                Method = HttpVerb.Get,
                Path = $"/business-customer-information",
                Query = new Dictionary<string, string>
                {
                    { "socialReason", socialReason},
                    { "zipCode", zipCode}
                }
            };

            var responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/get_customer_bySiret_BadRequest.json").ConfigureAwait(false));
            var response = new ProviderServiceResponse
            {
                Status = 400,
                Headers = new Dictionary<string, object>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                },
                Body = Match.Type(responseBody)
            };

            MockProviderService.Given("Get business customer information by SocialReason and ZipCode - Bad request(Bad zipcode)")
                .UponReceiving("Valid SocialReason and invalid ZipCode")
                .With(request)
                .WillRespondWith(response);

            HttpResponseMessage httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, $"/business-customer-information?socialReason={socialReason}&zipCode={zipCode}")).ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.BadRequest, httpResponse.StatusCode);
            MockProviderService.VerifyInteractions();
        }

        [Fact]
        public async Task BusinessCustomerConsumer_GetByInexistantSocialReasonAndZipCode_Return404NOTFOUNDWithoutInformation()
        {
            string socialReason = "1";
            string zipCode = "2";
            var request = new ProviderServiceRequest
            {
                Method = HttpVerb.Get,
                Path = $"/business-customer-information",
                Query = new Dictionary<string, string>
                {
                    { "socialReason", socialReason},
                    { "zipCode", zipCode}
                }
            };
            var responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/get_customer_byId_NotFound.json").ConfigureAwait(false));
            var response = new ProviderServiceResponse
            {
                Status = 404,
                Headers = new Dictionary<string, object>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                },
                Body = Match.Type(responseBody)
            };
            MockProviderService.Given("Get business customer information by SocialReason and ZipCode - Not found")
                .UponReceiving("Not existing SocialReason and ZipCode")
                .With(request)
                .WillRespondWith(response);

            HttpResponseMessage httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, $"/business-customer-information?socialReason={socialReason}&zipCode={zipCode}")).ConfigureAwait(false);
            object content = JsonConvert.DeserializeObject(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);
            Assert.Equal(responseBody, content);
            MockProviderService.VerifyInteractions();
        }
    }
}