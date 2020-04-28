using System.Threading;
using Kafka.Domain.Common.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace KafkaWebConsumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            CreateWebHostBuilder(args, cancellationTokenSource).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args,CancellationTokenSource cancellationTokenSource) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
