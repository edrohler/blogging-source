using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data.Models
{
    public class Employee : Person 
    {
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public double Salary { get; set; }
        public int VacationTotal { get; set; }
        public int VacationUsed { get; set; }
    }
}
