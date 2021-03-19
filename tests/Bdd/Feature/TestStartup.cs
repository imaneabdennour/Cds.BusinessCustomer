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
        }
        // This method gets called by the runtime. Use this method to configurethe HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionMonithorLogging();
            }
        }
    }
}
