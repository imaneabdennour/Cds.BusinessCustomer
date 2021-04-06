using Cds.Foundation.Test;
using Cds.Foundation.Test.Pact.Provider;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Cds.BusinessCustomer.Tests.ProviderPact
{ 
    /// <summary>
    /// Defines the SellerClientInvoiceWorker provider tests
    /// </summary>
    public class SellerClientInvoiceWorkerProviderTests : BaseProviderTests<BusinesCustomerProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SellerClientInvoiceWorkerProviderTests"/> class
        /// </summary>
        /// <param name="output">The Xunit output</param>
        /// <param name="provider">The provider</param>
        public SellerClientInvoiceWorkerProviderTests(ITestOutputHelper output, BusinesCustomerProvider provider) : base(output, provider)
        {
            ProviderStates.Add("get eligible provider returns OK", async () => await MockProvidersApiResponse().ConfigureAwait(false));
        }

#pragma warning disable S125
        [Fact]
        public Task Provider_SellerClientInvoiceWorker() => EnsureProviderHonoursPactAsync();

        private async Task MockProvidersApiResponse()
        {
            await MockBusinessCustomerApiResponse();
        }
#pragma warning restore S125
        private static async Task MockBusinessCustomerApiResponse()
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:22038/business-customer-information/123456")
            };

            HttpResponseMessage httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/SuccessResponseById.json")
                   .ConfigureAwait(false)),
            };

            GlobalServiceHandler.AddResponseMap(httpRequest, httpResponse);

        }
    }
}
