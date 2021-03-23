using Cds.BusinessCustomer.Api.Bootstrap;
using Cds.BusinessCustomer.Tests.Bdd.Feature;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace Cds.TestFormationDotnetcore.Tests.Bdd
{
    /* A WebApplicationFactory is a factory for bootstrapping an application in memory for functional end to end tests. 
     It needs to be passed a type parameter, which is basically a typei n the entry point assembly of the application. 
     Typically the Startup or Program classes can be used.
    */
    public class TestWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Production");

            builder.ConfigureTestServices(
                    services => {
#pragma warning disable S125
                        // Add your GLOBAL mocks here
                        /* Exemple to mock HttpClient :
                         services
                           .AddHttpClient([
                        +6])
                           .AddHttpMessageHandler(() => new GlobalServiceHandler());
                        */
                        services.AddDefaultHttpClient();

#pragma warning restore S125
                    });

            base.ConfigureWebHost(builder);
        }
    }
}
