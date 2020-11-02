using Microsoft.AspNetCore.Mvc;
using Telerik.Reporting.Services;
using Telerik.WebReportDesigner.Services;
using Telerik.WebReportDesigner.Services.Controllers;

namespace MSWACS.AspNetCore.Web.Controllers
{
    [Route("api/[controller]")]
    public class ReportDesignerController : ReportDesignerControllerBase
    {
        public ReportDesignerController(IReportDesignerServiceConfiguration reportDesignerServiceConfiguration,
            IReportServiceConfiguration reportServiceConfiguration) 
            : base(reportDesignerServiceConfiguration, reportServiceConfiguration)
        { }
    }
}
