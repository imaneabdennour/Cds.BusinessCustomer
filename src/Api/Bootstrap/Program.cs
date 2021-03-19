using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cds.BusinessCustomer.Api.Bootstrap
{
    /// <summary>
    /// Entry point class used at runtime.
    /// </summary>
    /// <remarks>
    /// ⚠ DO NOT modify this file unless you know what you are doing!
    /// </remarks>
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates the host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    ConfigureWebHostBuilder(webBuilder);
                });

        /// <summary>
        /// Builds the web host.;
        /// </summary>
        /// <param name="webBuilder">The web host  builder</param>
        /// <returns></returns>
        public static IWebHostBuilder ConfigureWebHostBuilder(IWebHostBuilder webBuilder)
        {
            webBuilder
                .ConfigurePorts()
                .ConfigureAppConfiguration((context, builder) => AddConfiguration(builder))
                .ConfigureLogging((context, builder) => AddLogging(context, builder))
                .UseMetrics()
                .UseStartup<Startup>();

            return webBuilder;
        }

        /// <summary>
        /// Add specific configuration.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private static void AddConfiguration(IConfigurationBuilder builder)
        {
            // Because appSettings, appSettings.<Environment>, EnvironmentVariables, command line configuration providers
            // have been added by-design with asp.net core default host builder
            // only add your additional configuration providers here
            builder
                 // Add Kubernetes Config Map from path stored in `KUBERNETES_CONFIGMAP_PATH` environment variable.
                .AddKubernetesConfigMap()
                // Add Kubernetes Secrets from path stored in `KUBERNETES_SECRETS_PATH`environment variable.
                .AddKubernetesSecrets();
        }

        /// <summary>
        /// Add specific logging capabilities.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="builder">The builder.</param>
        private static void AddLogging(WebHostBuilderContext context, ILoggingBuilder builder)
        {
            builder
                .ClearProviders();

            if (context.HostingEnvironment.IsDevelopment())
            {
                builder
                    .AddConsole()
                    .AddDebug();
            }

            builder
                .AddConfiguration(context.Configuration)
                .AddMonithorLog4Net()
            ;
        }
    }
}
