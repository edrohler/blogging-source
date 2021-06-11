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

        /// <summary>
        /// Gets all Categories
        /// </summary>
        /// <returns>All available categories.</returns>
        /// <response code="200">Successfully retreived caetegories.</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Supplier>), 200)]
        public IActionResult Get()
        {
            IEnumerable<Supplier> vm = Service.GenerateSupplierData();

            return Ok(vm);
        }

        //[HttpGet]
        //public Supplier GetById(int id)
        //{
        //    return Service.GenerateSupplierData().Where(x => x.SupplierId == id).Single();
        //}
    }
}
