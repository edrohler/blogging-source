using CommonHelpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleData.Api.Models
{
    public class Customer : Person
    {
        public int Id { get; set; }
    }
}
