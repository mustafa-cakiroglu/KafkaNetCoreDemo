using System;
using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Winton.Extensions.Configuration.Consul;
using Winton.Extensions.Configuration.Consul.Parsers.Json;

namespace Kafka.Domain.Common.Configuration
{
    public static class ConfigurationExtensions
    {
        public static IWebHostBuilder AddConsulConfigurationServer(this IWebHostBuilder webHost, string consulUrl, string serviceName, CancellationTokenSource cancellationTokenSource)
        {
            return webHost
                .ConfigureAppConfiguration(
                    (_, builder) =>
                    {
                        builder
                            .AddConsul(
                                serviceName,
                                cancellationTokenSource.Token,
                                options =>
                                {
                                    options.ConsulConfigurationOptions =
                                        cco => cco.Address = new Uri(consulUrl);
                                    options.Optional = true;
                                    options.ReloadOnChange = true;
                                    options.OnLoadException = exceptionContext => exceptionContext.Ignore = true;
                                    //options.Parser = new SimpleConfigurationParser();
                                    options.Parser = new JsonConfigurationParser();
                                })
                            .AddEnvironmentVariables();
                    });
        }
    }
}
