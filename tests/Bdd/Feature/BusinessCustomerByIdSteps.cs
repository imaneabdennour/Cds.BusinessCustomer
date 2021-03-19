using Cds.BusinessCustomer.Api.Bootstrap;
using Cds.BusinessCustomer.Api.CustomerFeature.Validation;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Abstractions;
using Cds.TestFormationDotnetcore.Infrastructure;
using Cds.TestFormationDotnetcore.Tests.Bdd;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium.Remote;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;
//using TechTalk.SpecRun.Common;

namespace Cds.BusinessCustomer.Tests.Bdd.Feature
{
    [Binding]
    public class BusinessCustomerByIdSteps : IClassFixture<TestWebApplicationFactory>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Startup> _factory;
        protected HttpResponseMessage Response { get; set; }


        public BusinessCustomerByIdSteps(TestWebApplicationFactory factory)
        {
            _factory = factory.WithWebHostBuilder(
                builder => builder.ConfigureTestServices(
                    services => {
#pragma warning disable S125                        
                        services
                          .AddScoped<ICartegieApi, CartegieApi>()
                          .AddScoped<IParametersHandler, ParametersHandler>();
                          //.AddSingleton(_configuration.GetSection("CartegieConfiguration").Get<CartegieConfiguration>());
#pragma warning restore S125
                    }));

           // _client = _factory.CreateClient();

            // Create a test client using the factory instance
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"http://localhost/") // The base address of the test server is http://localhost
            });
        }

        [When(@"the Business Customer API receives the get request with Id:""(.*)""")]
        public async Task WhenTheBusinessCustomerAPIReceivesTheGetRequestWithId(string id)
        {
           var getRelativeUri = new Uri("business-customer-definition/", UriKind.Relative);
            Response = await _client.GetAsync(id).ConfigureAwait(false);
        }
        
        [Then(@"the response status is ""(.*)""")]
        public void ThenTheResponseStatusIs(int statusCode)
        {
            // validate the response status code 
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }
        
        [Then(@"the Business Customer API sends the information related to the business customer:")]
        public void ThenTheBusinessCustomerAPISendsTheInformationRelatedToTheBusinessCustomer(Table table)
        {
            // validate the response content 
            var responseData = Response.Content.ReadAsStringAsync().Result;
            // extracting from table dynamically
           // dynamic data = table.CreateDynamicInstance();
            Assert.Equal(table.ToString(), responseData);
        }
    }
}
