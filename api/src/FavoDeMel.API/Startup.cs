using AutoMapper;
using FavoDeMel.API.Extensions;
using FavoDeMel.Domain.Models.Settings;
using FavoDeMel.Infra.Application.ExtensionsMethods;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FavoDeMel.API
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        private readonly AppSettings _appSettings;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            _appSettings = configuration.GetAppSettings();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Formatting = Formatting.Indented;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
            services.AddControllers();
            services.Configure<AppSettings>(c =>
            {
                c.Data = _appSettings.Data;
                c.Swagger = _appSettings.Swagger;
                c.RabbitMq = _appSettings.RabbitMq;
            });

            services
                .RegisterServices()
                .RegisterRepository(_appSettings)
                .RegisterFinders()
                .RegisterCommandHandle()
                .RegisterRabbitMq(_appSettings)
                .AddAutoMapper(typeof(Startup))
                .ConfigureSwagger(_appSettings.Swagger);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowSpecificOrigin");

            app.UseSwagger()
                .UseSwaggerUI(s => { s.SwaggerEndpoint($"/swagger/v1/swagger.json", "Projeto Favo de Mel v1.0"); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
