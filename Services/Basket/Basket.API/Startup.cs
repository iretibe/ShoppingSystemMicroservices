using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Discount.GRPC.Protos;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Basket.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Redis Configuration
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = Configuration.GetValue<string>("CacheSettings:ConnectionString");
            });

            services.AddScoped<IBasketRepository, BasketRepository>();

            services.AddAutoMapper(typeof(Startup));

            //Used to add grpc client to consume the discount grpc service
            services
                .AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
                (opt => opt.Address = new Uri(Configuration["GrpcSettings:DiscountUrl"]));

            services.AddScoped<DiscountGrpcService>();


            //Start MassTransit RabbitMQ Configuration**************
            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(Configuration["EventBusSettings:HostAddress"]);
                });
            });

            //services.AddMassTransitHostedService();
            //End MassTransit RabbitMQ Configuration**************

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
