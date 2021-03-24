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
    public class GetCustomerBySiretSteps
    {
        protected HttpResponseMessage Response { get; set; }

        [Given(@"a Business Customer with the Siret : ""(.*)""")]
        public void GivenABusinessCustomerWithTheSiret(string siret)
        {
            //Hooks.mockCartegieApi.Setup(x => x.GetInfosById(It.IsAny<string>())).Returns(SingleTask());
        }

        [When(@"the Business Customer API receives the get request with Siret : ""(.*)""")]
        public async Task WhenTheBusinessCustomerAPIReceivesTheGetRequestWithSiret(string siret)
        {
            Response = await BusinessCustomerHelper.GetBusinessCustomersBySiret(siret);
        }

        [Then(@"the response status is : ""(.*)""")]
        public void ThenTheResponseStatusIs(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;

            Response.StatusCode.Should().Be(expectedStatusCode);
        }
        
        [Then(@"the Business Customer API sends business customer information :")]
        public void ThenTheBusinessCustomerAPISendsBusinessCustomerInformation(Table table)
        {
            // validate the response content 
            var expected = BusinessCustomerHelper.GetCustomerRequestFromTable(table);
            var actual = BusinessCustomerHelper.GetCustomerRequestFromResponse(Response);

            actual.Name.Should().Be(expected.Name);
            actual.Siret.Should().Be(expected.Siret);
            actual.City.Should().Be(expected.City);
        }
    }
}
