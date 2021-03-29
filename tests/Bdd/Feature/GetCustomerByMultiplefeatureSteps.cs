using Cds.BusinessCustomer.Tests.Bdd.Core;
using FluentAssertions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cds.BusinessCustomer.Tests.Bdd.Feature
{
    [Binding]
    public class GetCustomerByMultiplefeatureSteps
    {
        protected HttpResponseMessage Response { get; set; }

        [Given(@"a Business Customer with the socialreason : ""(.*)"" and zipcode : ""(.*)"" and request to CartegieApi returns :")]
        public void GivenABusinessCustomerWithTheSocialreasonAndZipcodeAndRequestToCartegieApiReturns(string socialReason, string zipCode, Table table)
        {
            new InMemoryCartegieApi(table);
        }

        [When(@"the Business Customer API receives the get request with socialreason : ""(.*)"" and zipcode : ""(.*)""")]
        public async Task WhenTheBusinessCustomerAPIReceivesTheGetRequestWithSocialreasonAndZipcode(string socialReason, string zipCode)
        {
            Response = await BusinessCustomerHelper.GetBusinessCustomersByMultiple(socialReason, zipCode);
        }


        [Then(@"the response status is:""(.*)""")]
        public void ThenTheResponseStatusIs(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;

            Response.StatusCode.Should().Be(expectedStatusCode);
        }

        [Then(@"the Business Customer API sends business customer information  :")]
        public void ThenTheBusinessCustomerAPISendsBusinessCustomerInformation(Table table)
        {
            var expected = BusinessCustomerHelper.GetCustomersRequestFromTable(table);
            var actual = BusinessCustomerHelper.GetCustomersRequestFromResponse(Response);

            for(int i=0; i<expected.Count; i++) { 
                actual[i].Name.Should().Be(expected[i].Name);
                actual[i].Id.Should().Be(expected[i].Id);
                actual[i].Adress.Should().Be(expected[i].Adress);
            }           
        }
    }
}
