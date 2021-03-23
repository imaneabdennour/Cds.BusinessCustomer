using Cds.BusinessCustomer.Api.Bootstrap;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Abstractions;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Dtos;
using Cds.TestFormationDotnetcore.Infrastructure;
using Cds.TestFormationDotnetcore.Tests.Bdd;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace Cds.BusinessCustomer.Tests.Bdd.Feature
{
    [Binding]
    public class BusinessCustomerByIdSteps : IClassFixture<TestWebApplicationFactory>
    {
        private readonly Mock<ICartegieApi> mockCartegieApi;
        protected HttpResponseMessage Response { get; set; }
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public BusinessCustomerByIdSteps(TestWebApplicationFactory factory)
        {
            mockCartegieApi = new Mock<ICartegieApi>();

            _factory = factory.WithWebHostBuilder(
                builder => builder.ConfigureTestServices(
                    services =>
                    {
                        services.AddScoped<ICartegieApi, CartegieApi>();
                    }));

            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"http://localhost:22038/business-customer-definition") // The base address of the test server
            }); //44383
        }

        [Given(@"a Business Customer with the Id : ""(.*)""")]
        public void GivenABusinessCustomerWithTheId(string id)
        {
            // mock the behavior of the cartegieApiMock
            mockCartegieApi.Setup(x => x.GetInfosById(It.IsAny<string>())).Returns(SingleTask());
        }
        
        [When(@"the Business Customer API receives the get request with Id : ""(.*)""")]
        public async Task WhenTheBusinessCustomerAPIReceivesTheGetRequestWithId(string id)
        {
            Response = await _client.GetAsync(id).ConfigureAwait(false);
        }
        
        [Then(@"the response status is : ""(.*)""")]
        public void ThenTheResponseStatusIs(int statusCode)
        {
            // validate the response status code 
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }
        
        [Then(@"the Business Customer API sends business customer information :")]
        public void ThenTheBusinessCustomerAPISendsBusinessCustomerInformation(Table table)
        {
            //ScenarioContext.Current.Pending();
        }

        private Task<CustomerSingleSearchDTO> SingleTask()
        {
            return Task.FromResult(new CustomerSingleSearchDTO()
            {
                Name = "Imane",
                Adress = "Maarif",
                City = "Casablanca",
                Civility = "Marocaine",
                NafCode = "35678899",
                Phone = "+21268085321",
                Siret = "78945612378456",
                SocialReason = "rs456",
                ZipCode = "20100"
            });
        }
    }
}
