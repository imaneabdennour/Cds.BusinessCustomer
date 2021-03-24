using Cds.BusinessCustomer.Api.Bootstrap;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Abstractions;
using Cds.TestFormationDotnetcore.Infrastructure;
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

        public static Mock<ICartegieApi> mockCartegieApi;

        /// <summary>
        /// before feature method
        /// </summary>
        [BeforeFeature]
        public static void BeforeFeature()
        {
            mockCartegieApi = new Mock<ICartegieApi>();

            _host = Program.ConfigureWebHostBuilder(WebHost.CreateDefaultBuilder())
                .UseEnvironment(Environments.Development)
                .UseUrls(WebHostUri.ToString())
                 .ConfigureAppConfiguration((hostingContext, config) =>
                 {
                     config.AddJsonFile(Constants.TestConfigurationFile);
                 })
                .ConfigureTestServices(services =>
                {
                    services.AddScoped<ICartegieApi, CartegieApi>();
                })

                .Build();
            _host.Start();
        }

        /// <summary>
        /// after test run method
        /// </summary>
        [AfterFeature]
        public static async Task Afterfeature()
        {
            await _host.StopAsync().ConfigureAwait(false);
            _host.Dispose();
        }
    }
}
