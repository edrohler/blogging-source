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
    public class CustomerController : BaseApiController
    {
        public CustomerController(ILogger<CustomerController> logger)
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
            List<Customer> vm = new();

            for (int i = 1; i < Service.GeneratePeopleData().Count() + 1; i++)
            {
                Person person = Service.GeneratePeopleData().ElementAt(i - 1);
                Customer customer = new()
                {
                    Id = i,
                    Name = $"Customer {i}",
                    Age = person.Age,
                    DateOfBirth = person.DateOfBirth,
                    Gender = person.Gender
                };
                vm.Add(customer);
            }

            return Ok(vm);
        }

        /// <summary>
        /// Gets a single Customer by id.
        /// </summary>
        /// <param name="id">The requested customer identifier.</param>
        /// <returns>The requested customer.</returns>
        /// <response code="200">The customer was successfully retrieved.</response>
        /// <response code="404">The customer does not exist.</response>
        [HttpGet("id:int")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Customer), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            List<Customer> vm = new();

            for (int i = 1; i < Service.GeneratePeopleData().Count() + 1; i++)
            {
                Person person = Service.GeneratePeopleData().ElementAt(i - 1);
                Customer customer = new()
                {
                    Id = i,
                    Name = $"Customer {i}",
                    Age = person.Age,
                    DateOfBirth = person.DateOfBirth,
                    Gender = person.Gender
                };
                vm.Add(customer);
            }

            return Ok(vm.Where(x => x.Id == id));
        }

        /// <summary>
        /// Gets a single Customer by name.
        /// </summary>
        /// <param name="name">The requested customer name.</param>
        /// <returns>The requested customer.</returns>
        /// <response code="200">The customer was successfully retrieved.</response>
        /// <response code="404">The customer does not exist.</response>
        [HttpGet("name:string")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Customer), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(string name)
        {
            List<Customer> vm = new();

            for (int i = 1; i < Service.GeneratePeopleData().Count() + 1; i++)
            {
                Person person = Service.GeneratePeopleData().ElementAt(i - 1);
                Customer customer = new()
                {
                    Id = i,
                    Name = $"Customer {i}",
                    Age = person.Age,
                    DateOfBirth = person.DateOfBirth,
                    Gender = person.Gender
                };
                vm.Add(customer);
            }

            return Ok(vm.Where(x => x.Name == name));
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
            int count = Service.GeneratePeopleData().Count() + 1;
            customer.Id = count;
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }
    }
}
