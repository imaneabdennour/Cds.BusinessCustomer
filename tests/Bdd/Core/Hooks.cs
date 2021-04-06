using Cds.BusinessCustomer.Api.Bootstrap;
using Cds.BusinessCustomer.Infrastructure;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Abstractions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cds.BusinessCustomer.Tests.Bdd.Core
{
    /// <summary>
    /// Hook class used as an interceptor before AllTests, Before each feature and before Each Test
    /// </summary>
    [Binding]
    public sealed class Hooks
    {
        /// <summary>
        /// web host private member
        /// </summary>
        private static IWebHost _host;
        
        /// <summary>
        /// The web host Uri.
        /// </summary>
        public static readonly Uri WebHostUri = new Uri(Constants.HooksBaseIp);
        public static InMemoryCartegieApi TestCartegieApi;
        public static Mock<ICartegieApi> mockCartegieApi = new Mock<ICartegieApi>(MockBehavior.Strict);

        /// <summary>
        /// before feature method
        /// </summary>
        [BeforeTestRun]
        public static void BeforeFeature()
        {
            //TestCartegieApi = new InMemoryCartegieApi();

            _host = Program.ConfigureWebHostBuilder(WebHost.CreateDefaultBuilder())
                .UseEnvironment(Environments.Development)
                .UseUrls(WebHostUri.ToString())
                 .ConfigureAppConfiguration((hostingContext, config) =>
                 {
                     config.AddJsonFile(Constants.TestConfigurationFile);
                 })
                .ConfigureTestServices(services =>
                {
                    //services.AddSingleton<ICartegieApi>(TestCartegieApi);
                    services.AddScoped(ser => mockCartegieApi);
                    services.AddScoped(ser => mockCartegieApi.Object);
                })

                .Build();
            _host.Start();
        }

        /// <summary>
        /// after test run method
        /// </summary>
        [AfterTestRun]
        public static async Task Afterfeature()
        {
            await _host.StopAsync().ConfigureAwait(false);
            _host.Dispose();
        }
    }
}
