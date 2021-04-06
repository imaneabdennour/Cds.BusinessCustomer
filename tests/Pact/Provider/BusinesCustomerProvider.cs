using Cds.BusinessCustomer.Api.Bootstrap;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Abstractions;
using Cds.Foundation.Test.Pact.Provider;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cds.BusinessCustomer.Tests.ProviderPact { 
    /// <summary>
    /// Defines the SellerClientInvoiceWorker provider
    /// </summary>
    public class BusinesCustomerProvider : BaseProvider
    {
        public static InMemoryCartegieApi TestCartegieApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinesCustomerProvider"/> class
        /// </summary>
        public BusinesCustomerProvider() : base()
        {
            TestCartegieApi = new InMemoryCartegieApi();

            Host = Program.CreateHostBuilder(new string[0])
                    .ConfigureWebHostDefaults(builder =>
                        builder.UseEnvironment("Development")
                            .UseUrls(WebHostUri)
                            .ConfigureTestServices(services =>
                            {
                                services.AddSingleton<ICartegieApi>(TestCartegieApi);
#pragma warning restore S125
                            }))
                            .Build();

            Host.Start();
        }
    }
}