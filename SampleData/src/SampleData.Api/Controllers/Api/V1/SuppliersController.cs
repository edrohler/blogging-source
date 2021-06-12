namespace SampleData.Api.Controllers.Api.V1
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Sample.Data.Models;
    using Sample.Data.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class SuppliersController : BaseApiController
    {
        public SuppliersController(ILogger<SuppliersController> logger)
            : base(logger)
        { }

        /// <summary>
        /// Gets all suppliers
        /// </summary>
        /// <returns>All available susppliers.</returns>
        /// <response code="200">Successfully retreived caetegories.</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Supplier>), 200)]
        public IActionResult Get()
        {
            Logger.LogInformation($"{DateTime.Now} - type: {GetType().Name} - method: {MethodBase.GetCurrentMethod()} ");
            return Ok(Suppliers.GetSuppliers());
        }

        /// <summary>
        /// Gets a single supplier by id
        /// </summary>
        /// <param name="id">The requested supplier identifier.</param>
        /// <returns>The requested supplier.</returns>
        /// <response code="200">The supplier was successfully retrieved.</response>
        /// <response code="404">The supplier does not exist.</response>
        [HttpGet("id:string")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Supplier), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(string id)
        {
            Logger.LogInformation($"{DateTime.Now} - type: {GetType().Name} - method: {MethodBase.GetCurrentMethod()} - params: id={id}");
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
        [ProducesResponseType(typeof(Supplier), 201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Supplier supplier, ApiVersion apiVersion)
        {
            Guid id = Guid.NewGuid();
            supplier.Id = id;
            Logger.LogInformation($"{DateTime.Now} - type: {GetType().Name} - method: {MethodBase.GetCurrentMethod()} - params: supplier={supplier}");
            return CreatedAtAction(nameof(Get), new { id = supplier.Id }, supplier);
        }
    }
}
