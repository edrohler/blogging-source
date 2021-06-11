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


        /// <summary>
        /// Gets all Categories
        /// </summary>
        /// <returns>All available categories.</returns>
        /// <response code="200">Successfully retreived caetegories.</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Category>), 200)]
        public IActionResult Get()
        {
            IEnumerable<Category> vm = Service.GenerateCategoryData();

            return Ok(vm);
        }

        /// <summary>
        /// Gets a single category.
        /// </summary>
        /// <param name="id">The requested category identifier.</param>
        /// <returns>The requested category.</returns>
        /// <response code="200">The category was successfully retrieved.</response>
        /// <response code="404">The category does not exist.</response>
        [HttpGet("id:int")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Category), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            Category vm = Service.GenerateCategoryData().Where(x => x.CategoryId == id).Single();

            return Ok(vm);
        }

        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="category">The category to create.</param>
        /// <param name="apiVersion">The requested API version.</param>
        /// <returns>The created category.</returns>
        /// <response code="201">The category was successfully created.</response>
        /// <response code="400">The category was invalid.</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Category), 201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Category category, ApiVersion apiVersion)
        {
            int catNum = Service.GenerateCategoryData().Count() + 1;
            category.CategoryId = catNum;
            return CreatedAtAction(nameof(Get), new { id = category.CategoryId }, category);
        }
    }
}
