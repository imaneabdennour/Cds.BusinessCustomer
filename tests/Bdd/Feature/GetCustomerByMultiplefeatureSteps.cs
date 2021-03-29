using Cds.BusinessCustomer.Tests.Bdd.Core;
using FluentAssertions;
using System;
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
            // validate the response content 
            var expected = BusinessCustomerHelper.GetCustomersRequestFromTable(table);
            var actual = BusinessCustomerHelper.GetCustomersRequestFromResponse(Response);

            actual[0].Name.Should().Be(expected[0].Name);
            actual[0].Id.Should().Be(expected[0].Id);
            actual[0].Adress.Should().Be(expected[0].Adress);

            actual[1].Name.Should().Be(expected[1].Name);
            actual[1].Id.Should().Be(expected[1].Id);
            actual[1].Adress.Should().Be(expected[1].Adress);
        }
    }
}
