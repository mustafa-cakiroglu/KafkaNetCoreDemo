using Kafka.Domain.Common;
using Kafka.Domain.Common.Interfaces;
using KafkaWebProducer.Domain.Interfaces;
using KafkaWebProducer.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KafkaWebProducer
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

            services.AddCap(x =>
            {
                x.UseMongoDB(Configuration["ConnectionString"]);
                x.UseKafka(Configuration["EventBusConnection"]);
            });

            services.AddScoped<IOrderService, OrderService>();
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
