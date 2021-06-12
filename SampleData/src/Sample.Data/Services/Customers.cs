namespace Sample.Data.Services
{
    using Sample.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class Customers : BaseService
    {
        public static IEnumerable<Customer> GetCustomers()
        {
            return Enumerable.Range(1, 15).Select(i => new Customer
            {
                FirstName = PersonGenerator.GenerateRandomFirstName(),
                LastName = PersonGenerator.GenerateRandomLastName(),
                Age = RandomGenerator.Next(25, 85),
                DateOfBirth = StartDate.AddDays(RandomGenerator.Next(DateRange)),
                Gender = Genders[RandomGenerator.Next(0, Genders.Length)],
                CreatedDate = StartDate.AddDays(RandomGenerator.Next(DateRange)),
                UpdatedDate = StartDate.AddDays(RandomGenerator.Next(DateRange))
            });
        }
    }
}
