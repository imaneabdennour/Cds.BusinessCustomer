using Cds.Foundation.Test.Pact.Provider;
using Cds.TestFormationDotnetcore.Api.Bootstrap;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Cds.TestFormationDotnetcore.Tests.Pact.Provider
{
    /// <summary>
    /// Defines the TestFormationDotnetcore provider
    /// </summary>
    public class TestFormationDotnetcoreProvider : BaseProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestFormationDotnetcoreProvider"/> class
        /// </summary>
        public TestFormationDotnetcoreProvider() : base()
        {
            Host = Program.CreateHostBuilder(new string[0])
                    .ConfigureWebHostDefaults(builder =>
                        builder.UseEnvironment("Development")
                            .UseUrls(WebHostUri)
                            .ConfigureTestServices(services =>
                            {

            #pragma warning disable S125
                                //Add your mocks here
                                /*Exemple to mock HttpClient :
                                 * services
                                   .AddHttpClient([MyHttpClient])
                                   .AddHttpMessageHandler(() => new GlobalServiceHandler());
                                */
            #pragma warning restore S125
                            }))
                            .Build();

            Host.Start();
        }
    }
}