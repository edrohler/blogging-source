using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;

namespace TBACS.BlazorGridCustomStyle.Server
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
            services.AddCors(opts =>
            {
                opts.AddDefaultPolicy(p =>
                {
                    p.AllowAnyMethod();
                    p.AllowAnyHeader();
                    p.AllowAnyOrigin();
                });
            });

            services.AddControllers().AddNewtonsoftJson();
            services.AddRazorPages();

            // Configure dependencies for ReportsController.
            services.TryAddSingleton<IReportServiceConfiguration>(sp =>
            new ReportServiceConfiguration
            {
                ReportingEngineConfiguration = sp.GetService<IConfiguration>(),
                HostAppId = "Net5RestServiceWithCors",
                Storage = new FileStorage(),
                ReportSourceResolver = new UriReportSourceResolver(
                    System.IO.Path.Combine(sp.GetService<IWebHostEnvironment>().ContentRootPath, "Reports"))
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //// The default HSTS value is 30 days.
                //// You may want to change this for production scenarios.
                //// See https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
