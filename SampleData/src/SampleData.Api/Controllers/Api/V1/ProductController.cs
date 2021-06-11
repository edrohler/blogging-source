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
    public class ProductController : BaseApiController
    {
        public ProductController(ILogger<ProductController> logger)
            : base(logger)
        { }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Service.GenerateProductData();
        }
    }
}
