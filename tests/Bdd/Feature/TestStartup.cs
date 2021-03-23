using Cds.BusinessCustomer.Api.CustomerFeature.Validation;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Abstractions;
using Cds.TestFormationDotnetcore.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cds.BusinessCustomer.Tests.Bdd.Feature
{
    public class TestStartup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _environment;

        public TestStartup(IHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void ConfigureService(IServiceCollection services)
        {
            services.AddMvcCore();
            services
                // Registers a single HTTP client in `IHttpClientFactory` with Cdiscount default policies (Polly).
                .AddDefaultHttpClient()
                .AddSingleton(_configuration.GetSection("CartegieConfiguration").Get<CartegieConfiguration>())
                .AddScoped<ICartegieApi, CartegieApi>()
                // Registers api handler.
                .AddScoped<IParametersHandler, ParametersHandler>()
                // Injection of configuration :
                .AddSingleton(_configuration.GetSection("CartegieConfiguration").Get<CartegieConfiguration>());

        }
        // This method gets called by the runtime. Use this method to configurethe HTTP request pipeline.
        public void Configure(IApplicationBuilder application)
        {
            if (_environment.IsDevelopment())
            {
                // Uses development tools.
                application
                    .UseBrowserLink()
                    .UseDeveloperExceptionPage()
                    .UseWebApiExceptionHandler();
            }
            else
            {
                application.UseExceptionMonithorLogging();
            }

            application.UseRouting();

            application
                .UseResponseCompression()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapHealthChecks();
                });
            //if (_environment.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionMonithorLogging();
            //}
        }
    }
}
