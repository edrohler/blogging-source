using System;
using System.IO;
using System.Web;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;
using Telerik.WebReportDesigner.Services;
using Telerik.WebReportDesigner.Services.Controllers;

namespace MSWACS.AspNetMvc.Web.Controllers
{
    public class ReportDesignerController : ReportDesignerControllerBase
    {
        static readonly ReportServiceConfiguration ConfigurationInstance;
        static readonly ReportDesignerServiceConfiguration DesignerConfigurationInstance;

        static ReportDesignerController()
        {
            //This is the folder that contains the report definitions
            //In this case this is the Reports folder
            string reportsPath = Path.Combine(HttpContext.Current.Server.MapPath("~/"), "Reports");            

            //Setup the ReportServiceConfiguration
            ConfigurationInstance = new ReportServiceConfiguration
            {
                HostAppId = "AspNetMvcApp",
                Storage = new FileStorage(),
                ReportSourceResolver = CreateResolver(reportsPath),
                //ReportSharingTimeout = 1000,
                //ClientSessionTimeout = 20,
            };

            DesignerConfigurationInstance = new ReportDesignerServiceConfiguration
            {
                DefinitionStorage = new FileDefinitionStorage(reportsPath),
                SettingsStorage = new FileSettingsStorage(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Telerik Reporting"))
            };
        }

        public ReportDesignerController()
        {
            //Initialize the service configuration
            ReportServiceConfiguration = ConfigurationInstance;
            ReportDesignerServiceConfiguration = DesignerConfigurationInstance;
        }

        static IReportSourceResolver CreateResolver(string reportsPath)
        {
            return new UriReportSourceResolver(reportsPath)
                .AddFallbackResolver(new TypeReportSourceResolver());
        }
    }
}
