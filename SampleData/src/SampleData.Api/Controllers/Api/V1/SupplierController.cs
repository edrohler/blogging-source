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
    public class SupplierController : BaseApiController
    {
        public SupplierController(ILogger<SupplierController> logger)
            : base(logger)
        { }

        [HttpGet]
        public IEnumerable<Supplier> Get()
        {
            return Service.GenerateSupplierData();
        }
    }
}
