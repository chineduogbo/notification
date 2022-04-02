using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using PushNotificationService.FireBaseSetUp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PushNotificationService
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
            services.AddSingleton<IFirebaseConnector, FirebaseConnector>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PushNotificationService", Version = "v1" });
            });
            services.AddCors((
     options => options.AddPolicy("AllowCors",
     builder =>
     {
         builder
         .AllowAnyHeader()
          .AllowAnyMethod()
          .WithOrigins("*")
           .AllowAnyOrigin()
         .WithHeaders("Accept", "Content-type", "Origin", "X-Custom-Header");  //AllowSpecificHeaders;
                                                                               //AllowAllHeaders;

        })));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PushNotificationService v1"));
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PushNotificationService v1"));

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(policy =>
          policy.WithOrigins("*")
           .AllowAnyMethod()
           .AllowAnyOrigin()
           .AllowAnyHeader()
           .WithHeaders(HeaderNames.ContentType));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
