using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Data.Models;
using Sample.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleData.Api.Controllers.Api.V1
{
    public class CustomersController : BaseApiController
    {
        public CustomersController(ILogger<CustomersController> logger)
            :base(logger)
        { }

        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <returns>All available customers.</returns>
        /// <response code="200">Successfully retrieved customers.</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Customer>), 200)]
        public IActionResult Get()
        {
            return Ok(Customers.GetCustomers());
        }

        /// <summary>
        /// Gets a single Customer by id.
        /// </summary>
        /// <param name="id">The requested customer identifier.</param>
        /// <returns>The requested customer.</returns>
        /// <response code="200">The customer was successfully retrieved.</response>
        /// <response code="404">The customer does not exist.</response>
        [HttpGet("id:string")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Customer), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(string id)
        {
            return Ok(Customers.GetCustomers().Where(x => x.Id.ToString() == id));
        }

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="apiVersion"></param>
        /// <returns>The created customer</returns>
        /// <response code="201">The customer was successfully created.</response>
        /// <response code="400">The customer was invalid.</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Customer), 201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Customer customer, ApiVersion apiVersion)
        {
            Guid id = Guid.NewGuid();
            customer.Id = id;
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }
    }
}
