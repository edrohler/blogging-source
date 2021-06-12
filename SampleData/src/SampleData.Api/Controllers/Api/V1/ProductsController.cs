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
    public class ProductsController : BaseApiController
    {
        public ProductsController(ILogger<ProductsController> logger)
            : base(logger)
        { }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>All available products.</returns>
        /// <response code="200">Successfully retreived products.</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
        public IActionResult Get()
        {
            return Ok(Products.GetProducts());
        }

        /// <summary>
        /// Gets a single product by id.
        /// </summary>
        /// <param name="id">The requested product identifier.</param>
        /// <returns>The requested product.</returns>
        /// <response code="200">The product was successfully retrieved.</response>
        /// <response code="404">The product does not exist.</response>
        [HttpGet("id:string")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(string id)
        {
            return Ok(Products.GetProducts().Where(x => x.Id.ToString() == id));
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="product"></param>
        /// <param name="apiVersion"></param>
        /// <returns>The created product</returns>
        /// <response code="201">The product was successfully created.</response>
        /// <response code="400">The product was invalid.</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Product), 201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Product product, ApiVersion apiVersion)
        {
            Guid id = Guid.NewGuid();
            product.Id = id;
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
    }
}
