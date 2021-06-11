using CommonHelpers.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleData.Api.Controllers.Api.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BaseApiController : ControllerBase
    {
        internal readonly SampleDataService Service;
        internal ILogger<BaseApiController> Logger;
        public BaseApiController(ILogger<BaseApiController> logger)
        {
            Logger = logger;
            Service = new SampleDataService();
        }
    }
}
