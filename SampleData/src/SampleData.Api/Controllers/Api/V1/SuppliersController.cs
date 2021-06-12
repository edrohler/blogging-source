using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Data;
using Sample.Data.Models;
using Sample.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleData.Api.Controllers.Api.V1
{
    public class SuppliersController : BaseApiController
    {
        public SuppliersController(ILogger<SuppliersController> logger)
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
            return Ok(Suppliers.GetSuppliers());
        }

        /// <summary>
        /// Gets a single supplier by id.
        /// </summary>
        /// <param name="id">The requested supplier identifier.</param>
        /// <returns>The requested supplier.</returns>
        /// <response code="200">The supplier was successfully retrieved.</response>
        /// <response code="404">The supplier does not exist.</response>
        [HttpGet("id:string")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(string id)
        {
            return Ok(Suppliers.GetSuppliers().Where(x => x.Id.ToString() == id));
        }

        /// <summary>
        /// Creates a new supplier
        /// </summary>
        /// <param name="supplier"></param>
        /// <param name="apiVersion"></param>
        /// <returns>The created supplier</returns>
        /// <response code="201">The supplier was successfully created.</response>
        /// <response code="400">The supplier was invalid.</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Product), 201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Product supplier, ApiVersion apiVersion)
        {
            Guid id = Guid.NewGuid();
            supplier.Id = id;
            return CreatedAtAction(nameof(Get), new { id = supplier.Id }, supplier);
        }
    }
}
