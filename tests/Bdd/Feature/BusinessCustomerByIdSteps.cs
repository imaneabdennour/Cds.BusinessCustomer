using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Dtos;
using Cds.BusinessCustomer.Tests.Bdd.Core;
using FluentAssertions;
using Moq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cds.BusinessCustomer.Tests.Bdd.Feature
{
    [Binding]
    public class BusinessCustomerByIdSteps
    {
        protected HttpResponseMessage Response { get; set; }

        [Given(@"a Business Customer with the ID ""(.*)""")]
        public void GivenABusinessCustomerWithTheID(string id)
        {
            // mock the behavior of the cartegieApi
            Hooks.mockCartegieApi.Setup(x => x.GetInfosById(It.IsAny<string>())).Returns(SingleTask());
        }
        
        [When(@"the Business Customer API receives the get request with ID ""(.*)""")]
        public async Task WhenTheBusinessCustomerAPIReceivesTheGetRequestWithID(string id)
        {
            Response = await BusinessCustomerHelper.GetBusinessCustomers(id);
        }
        
        [Then(@"the response status is ""(.*)""")]
        public void ThenTheResponseStatusIs(int statusCode)
        {
            // validate the response status code 
            var expectedStatusCode = (HttpStatusCode)statusCode;

            Response.StatusCode.Should().Be(expectedStatusCode);
        }
        
        [Then(@"the Business Customer API sends business customer information:")]
        public void ThenTheBusinessCustomerAPISendsBusinessCustomerInformation(Table table)
        {
            // validate the response content 
            var expected = BusinessCustomerHelper.GetCustomerRequestFromTable(table);
            var actual = BusinessCustomerHelper.GetCustomerRequestFromResponse(Response);

            actual.Name.Should().Be(expected.Name);
            actual.Siret.Should().Be(expected.Siret);
            actual.City.Should().Be(expected.City);            
        }

        private Task<CustomerSingleSearchDTO> SingleTask()
        {
            return Task.FromResult(new CustomerSingleSearchDTO()
            {
                Name = "UBER PARTNER SUPPORT FRANCE SAS",
                Adress = "Maarif",
                City = "Casablanca56",
                Civility = "Marocaine",
                NafCode = "35678899",
                Phone = "+21268085321",
                Siret = "12345",
                SocialReason = "rs456",
                ZipCode = "20100"
            });
        }
    }
}
