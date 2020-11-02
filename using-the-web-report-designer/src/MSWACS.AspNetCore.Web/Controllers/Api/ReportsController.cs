using Microsoft.AspNetCore.Mvc;
using Telerik.Reporting.Services;
using Telerik.Reporting.Services.AspNetCore;

namespace MSWA.AspNetCore.Web.Controllers
{
    [Route("api/[controller]")]
    public class ReportsController : ReportsControllerBase
    {
        public ReportsController(IReportServiceConfiguration reportServiceConfiguration) 
            : base(reportServiceConfiguration)
        { }
    }
}
