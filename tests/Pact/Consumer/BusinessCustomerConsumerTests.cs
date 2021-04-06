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
        [Fact]
        public async Task BusinessCustomerConsumer_GetId_Return200OKWithInformation()
        {
            string customerId = "123456";
            // Arrange
            var request = new ProviderServiceRequest
            {
                Method = HttpVerb.Get,
                Path = $"/business-customer-information/{customerId}"
            };

            var responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"../../../Json/get_customer_body_success.json").ConfigureAwait(false));
            var response = new ProviderServiceResponse
            {
                Status = 200,
                Headers = new Dictionary<string, object>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                },
                Body = Match.Type(responseBody)
            };

            MockProviderService.Given("GetId")
                .UponReceiving("description")
                .With(request)
                .WillRespondWith(response);

            // Act
            HttpResponseMessage httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, $"/business-customer-information/{customerId}")).ConfigureAwait(false);
            // Assert
            object content = JsonConvert.DeserializeObject(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.Equal(responseBody, content);

            // Generation du pact
            MockProviderService.VerifyInteractions();

        }
    }
}
