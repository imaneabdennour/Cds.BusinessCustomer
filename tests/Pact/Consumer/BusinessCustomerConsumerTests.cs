using System.Collections.Generic;
using Cds.Foundation.Test.Pact.Consumer;
using Xunit;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Cds.BusinessCustomer.Api.CustomerFeature.ViewModels;
using PactNet.Mocks.MockHttpService.Models;
using Match = PactNet.Matchers.Match;
using System.Net.Http;
using Moq;
using Microsoft.Extensions.Options;
using System;
using System.Net;

namespace Cds.BusinessCustomer.Tests.ConsumerPact
{
    public class BusinessCustomerConsumerTests : BaseConsumerTests<BusinessCustomerConsumer>
    {
		public BusinessCustomerConsumerTests(BusinessCustomerConsumer consumer) : base(consumer) { }

		[Fact]
		public async Task GetTenantById_Ok()
		{			
			//Arrange
			string customerId = "a40354012";
			string path = $"/business-customer-information";

			string jsonBody = await File.ReadAllTextAsync(@"../../../Json/get_customer_body.json").ConfigureAwait(false);
			var body = JsonConvert.DeserializeObject(jsonBody);
			var tenantBody = JsonConvert.DeserializeObject<SingleCustomerViewModel>(jsonBody);

			var request = new ProviderServiceRequest
			{
				Method = HttpVerb.Get,
				Path = $"{path}/{customerId}"
			};

			var response = new ProviderServiceResponse
			{
				Status = 200,
				Headers = new Dictionary<string, object>
				{
					{ "Content-Type", "application/json; charset=utf-8" }
				},
				Body = Match.Type(body)
			};

			MockProviderService
				.UponReceiving("A GET request to retreive business customer details with id")
				.With(request)
				.WillRespondWith(response);

            // Create HTTP call 
            //var httpClient = new HttpClient();
            //var res = await httpClient.GetAsync($"http://localhost:9222/business-customer-information/{customerId}");
            //var json = await res.Content.ReadAsStringAsync();
            //var customerDetails = JsonConvert.DeserializeObject<SingleCustomerViewModel>(json);

            //string e = "UBER PARTNER SUPPORT FRANCE SAS";
            //Assert.Equal(e, customerDetails.Name);


            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, new Uri(MockProviderServiceBaseUri, path));

            using HttpClient httpClient = new HttpClient();
            // Act
            HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest).ConfigureAwait(false);
            object content = JsonConvert.DeserializeObject(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);

            MockProviderService.VerifyInteractions();


        }
	}
}
