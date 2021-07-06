namespace SampleData.Api.Controllers.Api.V1
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BaseApiController : ControllerBase
    {
        internal ILogger<BaseApiController> Logger;
        public BaseApiController(ILogger<BaseApiController> logger)
        {
            Logger = logger;
        }
    }
}
