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
    public class EmployeesController : BaseApiController
    {
        public EmployeesController(ILogger<EmployeesController> logger)
            :base (logger)
        { }

        /// <summary>
        /// Gets all employees
        /// </summary>
        /// <returns>All available employees.</returns>
        /// <response code="200">Successfully retrieved employees.</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Employee>), 200)]
        public IActionResult Get()
        {
            return Ok(Employees.GetEmployees());
        }

        /// <summary>
        /// Gets a single employee by id.
        /// </summary>
        /// <param name="id">The requested employee identifier.</param>
        /// <returns>The requested employee.</returns>
        /// <response code="200">The employee was successfully retrieved.</response>
        /// <response code="404">The employee does not exist.</response>
        [HttpGet("id:string")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(string id)
        {
            return Ok(Employees.GetEmployees().Where(x => x.Id.ToString() == id));
        }

        /// <summary>
        /// Creates a new employee
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="apiVersion"></param>
        /// <returns>The created employee</returns>
        /// <response code="201">The employee was successfully created.</response>
        /// <response code="400">The employee was invalid.</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Employee), 201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Employee employee, ApiVersion apiVersion)
        {
            Guid id = Guid.NewGuid();
            employee.Id = id;
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }
    }
}
