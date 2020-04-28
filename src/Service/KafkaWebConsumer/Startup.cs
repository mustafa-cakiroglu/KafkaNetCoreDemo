using Kafka.Domain.Common;
using Kafka.Domain.Common.Interfaces;
using Kafka.Domain.Common.ServiceDiscovery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KafkaWebConsumer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var serviceConfig = Configuration.GetServiceConfig();
            services.RegisterConsulServices(serviceConfig);

            services.AddCap(x =>
            {
                x.UseMongoDB(Configuration["MongoConnection"]);
                x.UseKafka(Configuration["EventBusConnection"]);
            });

            services.AddScoped<IEventManager, EventManager>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
