﻿namespace SampleData.Api.Controllers.Api.V1
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Sample.Data.Models;
    using Sample.Data.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

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
            Logger.LogInformation($"{DateTime.Now} - type: {GetType().Name} - method: {MethodBase.GetCurrentMethod()} ");
            return Ok(Categories.GetCategories());
        }

        /// <summary>
        /// Gets a single category by id
        /// </summary>
        /// <param name="id">The requested category identifier.</param>
        /// <returns>The requested category.</returns>
        /// <response code="200">The category was successfully retrieved.</response>
        /// <response code="404">The category does not exist.</response>
        [HttpGet("id:string")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Category), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(string id)
        {
            Logger.LogInformation($"{DateTime.Now} - type: {GetType().Name} - method: {MethodBase.GetCurrentMethod()} - params: id={id}");
            return Ok(Categories.GetCategories().Where(x => x.Id.ToString() == id).Single());
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
            Guid id = Guid.NewGuid();
            category.Id = id;

            Logger.LogInformation($"{DateTime.Now} - type: {GetType().Name} - method: {MethodBase.GetCurrentMethod()} - params: category={category}");
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }
    }
}
