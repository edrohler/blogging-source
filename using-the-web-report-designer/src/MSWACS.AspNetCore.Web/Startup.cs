using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;
using Telerik.WebReportDesigner.Services;

namespace MSWA.AspNetCore.Web
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
            // Add CORS (This is open for illustrative purposes)
            services.AddCors(opts =>
            {
                opts.AddDefaultPolicy(p =>
                {
                    p.AllowAnyOrigin();
                    p.AllowAnyMethod();
                    p.AllowAnyHeader();
                });
            });

            // Add WebAPI for ASP.NET Core
            services.AddControllers();

            // Add Razor Pages
            services.AddRazorPages()
                .AddNewtonsoftJson();

            // Add the IIS Synchronous IO
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // Configure dependencies for ReportServiceConfiguration.
            services.TryAddSingleton<IReportServiceConfiguration>(sp =>
                new ReportServiceConfiguration
                {
                    ReportingEngineConfiguration = sp.GetRequiredService<IConfiguration>(),
                    HostAppId = "DotNetCoreApp",
                    Storage = new FileStorage(),
                    ReportSourceResolver = new TypeReportSourceResolver()
                    .AddFallbackResolver(new UriReportSourceResolver(
                        Path.Combine(sp.GetService<IWebHostEnvironment>().ContentRootPath, "Reports")))
                });

            // Configure dependencies for ReportDesignerServiceConfiguration.  
            services.TryAddSingleton<IReportDesignerServiceConfiguration>(sp => new ReportDesignerServiceConfiguration {
                DefinitionStorage = new FileDefinitionStorage(Path.Combine(sp.GetService<IWebHostEnvironment>().ContentRootPath, "Reports")),
                SettingsStorage = new FileSettingsStorage(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Telerik Reporting")),
                ResourceStorage = new ResourceStorage(Path.Combine(sp.GetService<IWebHostEnvironment>().ContentRootPath, "Reports", "Resources")),
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Uses CORS
            app.UseCors();

            // Uses Static Files
            app.UseStaticFiles();

            // Uses Routing
            app.UseRouting();

            // Maps Web API and Razor Pages
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
