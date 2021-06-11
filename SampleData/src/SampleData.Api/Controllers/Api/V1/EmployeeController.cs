using CommonHelpers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleData.Api.Controllers.Api.V1
{
    public class EmployeeController : BaseApiController
    {
        public EmployeeController(ILogger<EmployeeController> logger)
            :base (logger)
        { }


        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            
            return Service.GenerateEmployeeData(true);
        }

    }
}
