using Cds.BusinessCustomer.Api.Bootstrap;
using Cds.BusinessCustomer.Infrastructure;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Abstractions;
using Cds.Foundation.Test;
using Cds.Foundation.Test.Pact.Provider;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;

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
                            .ConfigureAppConfiguration((hostingContext, config) =>
                            {
                                config.AddJsonFile(Constants.TestConfigurationFile);
                            })
                            .ConfigureTestServices(services =>
                            {
                                services
                                    .AddHttpClient("ProvidersApiClient")
                                    .AddHttpMessageHandler(builder => new GlobalServiceHandler())
                                ;
                                services.AddSingleton<ICartegieApi>(TestCartegieApi);
                            }))
                            .Build();

            Host.Start();
        }
    }
}