using CommonHelpers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleData.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleData.Api.Controllers.Api.V1
{
    public class EmployeeController : BaseApiController
    {
        public EmployeeController(ILogger<EmployeeController> logger)
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
            List<LocalEmployee> vm = new();

            for (int i = 1; i < Service.GenerateEmployeeData().Count(); i++)
            {
                Employee e1 = Service.GenerateEmployeeData().ElementAt(i - 1);
                LocalEmployee employee = new()
                {
                    Id = i,
                    Name = e1.Name,
                    Position = e1.Position,
                    Salary = e1.Salary,
                    StartDate = e1.StartDate,
                    VacationTotal = e1.VacationTotal,
                    VacationUsed = e1.VacationUsed
                };
                vm.Add(employee);
            }

            return Ok(vm);
        }

        /// <summary>
        /// Gets a single Customer by id.
        /// </summary>
        /// <param name="id">The requested employee identifier.</param>
        /// <returns>The requested employee.</returns>
        /// <response code="200">The employee was successfully retrieved.</response>
        /// <response code="404">The employee does not exist.</response>
        [HttpGet("id:int")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            List<LocalEmployee> vm = new();

            for (int i = 1; i < Service.GenerateEmployeeData().Count(); i++)
            {
                Employee e1 = Service.GenerateEmployeeData().ElementAt(i - 1);
                LocalEmployee employee = new()
                {
                    Id = i,
                    Name = e1.Name,
                    Position = e1.Position,
                    Salary = e1.Salary,
                    StartDate = e1.StartDate,
                    VacationTotal = e1.VacationTotal,
                    VacationUsed = e1.VacationUsed
                };
                vm.Add(employee);
            }

            return Ok(vm.Where(x => x.Id == id));
        }

        /// <summary>
        /// Gets a single Employee.
        /// </summary>
        /// <param name="name">The requested employee name.</param>
        /// <returns>The requested employee.</returns>
        /// <response code="200">The employee was successfully retrieved.</response>
        /// <response code="404">The employee does not exist.</response>
        [HttpGet("name:string")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(string name)
        {
            List<LocalEmployee> vm = new();

            for (int i = 1; i < Service.GenerateEmployeeData().Count(); i++)
            {
                Employee e1 = Service.GenerateEmployeeData().ElementAt(i - 1);
                LocalEmployee employee = new()
                {
                    Id = i,
                    Name = e1.Name,
                    Position = e1.Position,
                    Salary = e1.Salary,
                    StartDate = e1.StartDate,
                    VacationTotal = e1.VacationTotal,
                    VacationUsed = e1.VacationUsed
                };
                vm.Add(employee);
            }

            return Ok(vm.Where(x => x.Name == name));
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
        public IActionResult Post([FromBody] LocalEmployee employee, ApiVersion apiVersion)
        {
            int count = Service.GeneratePeopleData().Count() + 1;
            employee.Id = count;
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }
    }
}
