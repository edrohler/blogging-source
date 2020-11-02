using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Telerik.Reporting.Services.WebApi;
using Telerik.WebReportDesigner.Services.WebApi;

namespace MSWACS.AspNetMvc.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {

            ReportsControllerConfiguration.RegisterRoutes(GlobalConfiguration.Configuration);
            ReportDesignerControllerConfiguration.RegisterRoutes(GlobalConfiguration.Configuration);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
