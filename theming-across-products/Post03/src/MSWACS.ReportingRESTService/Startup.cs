using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;

namespace MSWACS.ReportingRESTService
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
            }

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
