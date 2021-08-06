using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Reporting.Services;
using Telerik.Reporting.Services.AspNetCore;

namespace TBACS.BlazorGridCustomStyle.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ReportsControllerBase
    {
        public ReportsController(IReportServiceConfiguration reportServiceConfiguration) : base(reportServiceConfiguration)
        {
        }
    }
}
