using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonHelpers.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SampleData.Api.Models;

namespace SampleData.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opts =>
            {
                opts.AddDefaultPolicy(p =>
                {
                    p.AllowAnyMethod();
                    p.AllowAnyHeader();
                    p.AllowAnyOrigin();
                });
            });

            services.AddControllers();

            services.AddApiVersioning(
                options =>
                {
                    options.ReportApiVersions = true;
                });

            services.AddSwaggerGen(opts =>
            {
                string title = "Sample Data API";
                string desc = "A simple web api with data.";

                OpenApiLicense license = new()
                {
                    Name = "MIT"
                };

                OpenApiContact contact = new()
                {
                    Name = "Eric Rohler",
                    Email = "development@ericrohler.com",
                    Url = new Uri("https://www.ericrohler.com")
                };

                opts.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = $"{title}",
                    Description = desc,
                    License = license,
                    Contact = contact
                });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample Data API");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
