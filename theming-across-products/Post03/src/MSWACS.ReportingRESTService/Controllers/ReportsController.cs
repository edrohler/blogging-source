using Microsoft.AspNetCore.Mvc;
using System.IO;
using Telerik.Reporting.Services;
using Telerik.Reporting.Services.AspNetCore;

namespace MSWACS.ReportingRESTService.Controllers
{
    public class ReportsController : ReportsControllerBase
    {
        public ReportsController(IReportServiceConfiguration reportServiceConfiguration)
            : base(reportServiceConfiguration)
        { }
    }
}
