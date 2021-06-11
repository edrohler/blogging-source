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
    public class CategoriesController : BaseApiController
    {
        public CategoriesController(ILogger<CategoriesController> logger)
            : base(logger)
        { }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return Service.GenerateCategoryData();
        }
    }
}
