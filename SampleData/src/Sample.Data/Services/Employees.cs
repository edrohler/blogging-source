using Sample.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data.Services
{
    public class Employees : BaseService
    {
        public static IEnumerable<Employee> GetEmployees()
        {
            return Enumerable.Range(1, 15).Select(i => new Employee
            {
                FirstName = PersonGenerator.GenerateRandomFirstName(),
                LastName = PersonGenerator.GenerateRandomLastName(),
                Age = RandomGenerator.Next(25, 85),
                DateOfBirth = StartDate.AddDays(RandomGenerator.Next(DateRange)),
                Gender = Genders[RandomGenerator.Next(0,Genders.Length)],
                CreatedDate = StartDate.AddDays(RandomGenerator.Next(DateRange)),
                UpdatedDate = StartDate.AddDays(RandomGenerator.Next(DateRange)),
                StartDate = DateTime.Today.AddYears(-RandomGenerator.Next(1, 20)).AddDays(-RandomGenerator.Next(1, 350)),
                Position = Positions[RandomGenerator.Next(1, Positions.Length)],
                Salary = RandomGenerator.Next(50000, 125000),
                VacationTotal = VacationTotal,
                VacationUsed = VacationTotal - RandomGenerator.Next(40, 70)
            });
        }
    }
}
